using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour 
{
	public void Restart() 
	{
		SceneManager.LoadScene(0);
	}
}