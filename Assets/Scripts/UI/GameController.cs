using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private int mRoomCompleted = 0;

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
	}

	void Start()
	{
		GameObject txtGO = GameObject.Find ("TxtRoomsCompleted") as GameObject;
		GameObject resetBtn = GameObject.Find ("BtnResetCounter") as GameObject;

		if (mRoomCompleted > 0)
		{
			if (txtGO && resetBtn)
				txtGO.GetComponent<Text> ().text = "Nombre de salles completée(s): " + mRoomCompleted;
		} else if (txtGO && resetBtn) 
		{
			txtGO.SetActive (false);
			resetBtn.SetActive (false);
		}
	}

    void SwitchRoom()
    {
        RenderSettings.ambientLight = Color.white;

        StartCoroutine(FadeToBlack());
    }

	void Update()
	{

	}

	public void ResetRoomCounter ()
	{
		mRoomCompleted = 0;
	}

	public void IncrementRoomCounter()
	{
		mRoomCompleted++;
        SwitchRoom();
	}

    IEnumerator FadeToBlack()
    {
        yield return new WaitForSeconds(5f);
    }
}
