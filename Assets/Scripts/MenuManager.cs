using UnityEngine;
using System.Collections;
 using UnityEngine.SceneManagement;
 
public class MenuManager : MonoBehaviour 
{
	public void PressButtonStart() 
	{
		SceneManager.LoadScene(1);
	}

	public void PressButtonQuit() 
	{
		Application.Quit ();
	}
}