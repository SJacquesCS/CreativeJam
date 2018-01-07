using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public Canvas mQuitMenu;
	public Button mStartGameButton;
	public Button mExitButton;

	void Start () 
	{
		mStartGameButton = mStartGameButton.GetComponent<Button> ();
		mExitButton = mExitButton.GetComponent<Button> ();
		mQuitMenu.enabled = false;
	}

	public void ExitPress()
	{
		mQuitMenu.enabled = true;
		mStartGameButton.enabled = false;
		mExitButton.enabled = false;
	}

	public void NoPress()
	{
		mQuitMenu.enabled = false;
		mStartGameButton.enabled = true;
		mExitButton.enabled = true;
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
