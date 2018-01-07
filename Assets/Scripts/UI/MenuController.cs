using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public Button mStartGameButton;
	public Button mExitButton;

	void Start () 
	{
		mStartGameButton = mStartGameButton.GetComponent<Button> ();
		mExitButton = mExitButton.GetComponent<Button> ();
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
