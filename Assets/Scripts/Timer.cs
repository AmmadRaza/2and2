using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public bool timerActivator, resetTimer;
	internal float seconds, counter, m_time;
	internal string timeInSeconds;

	// Use this for initialization
	void Start () 
	{	
		timerActivator = true;
		resetTimer = true;
		ResetTimer ();
		timeInSeconds = seconds + " seconds";
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if this certain timer is active..
		if (timerActivator == true) 
		{
			//start counting seconds.
			seconds = Time.time % 60;

			//this is to make sure whenever the game gets started, this will make sure the timer will get reset.
			if(resetTimer == true)
			{
				ResetTimer ();
				resetTimer = false;
			}

			// subtracting the time that has passed, and starting the counter from zero.
			counter = seconds - m_time;

			timeInSeconds =  (int)counter + " seconds";
		}
	}

	//the following method was made to reset the timer.
	internal void ResetTimer()
	{
		//this will get the exact time that has been passed
		m_time = seconds;
		counter = 0;
	}
}