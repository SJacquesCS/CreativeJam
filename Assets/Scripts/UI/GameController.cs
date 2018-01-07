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

    void SwitchRoom()
    {

    }

	public void ResetRoomCounter ()
	{
		mRoomCompleted = 0;
	}

	public void IncrementRoomCounter()
	{
		mRoomCompleted++;
<<<<<<< HEAD

=======
>>>>>>> e36c43d80e01c2ffcd53e4236df5500f9fa9e9c9
        SwitchRoom();
	}

    IEnumerator FadeToBlack()
    {
        yield return new WaitForSeconds(5f);
    }
}
