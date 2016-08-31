using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Collider colliderExit;
	public Collider[] colliderBadGuys;

	public SmileyGuy smileyGuy;
	public GameObject victoryPanel;

	public Text victoryPanelTimeText, timeText;

	public Timer timer;

	// Use this for initialization
	void Start () 
	{
		// following is the panel that gets disable on the start of the scene
		victoryPanel.SetActive(false);

		smileyGuy.onEventTriggerEnter += HandleSmileyGuyTriggerEnter;
	}
		
	void HandleSmileyGuyTriggerEnter(Collider collider)
	{
		//this will check which collider did smiley collide with 
		foreach (Collider a_collider in colliderBadGuys) 
		{
			// if collided with an enemy..
			if(collider == a_collider)
			{
				//reset
				Reset();
			}
			//if collided with exit sphere
			else if (collider == colliderExit) 
			{
				//end game
				EndGame();
			}
		}
	}

	// following function is get called when the smiley collide with end sphere
	void EndGame() 
	{
		//the timer will get disable
		timer.timerActivator = false;

		smileyGuy.Kill();

		//enable the the panel..
		victoryPanel.SetActive(true);
	}

	// following function is get called when the smiley collide with an enemy
	void Reset() 
	{
		//reset the timer
		timer.ResetTimer ();
		//reset the smiley
		smileyGuy.Reset();
	}

	// Update is called once per frame
	void Update () 
	{
		victoryPanelTimeText.text = timer.timeInSeconds;
		timeText.text = timer.timeInSeconds;
	}
}