using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private int mRoomCompleted = 1;
    private int mPlayerHealth;

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

        StartCoroutine(ChangeScene());
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

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);

        GameObject.Find("Black").GetComponent<Blackener>().Fade();

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(mRoomCompleted);

        RenderSettings.ambientLight = Color.black;
    }

    public void SetHealth(int health)
    {
        mPlayerHealth = health;

        if (mPlayerHealth <= 0)
        {
            mRoomCompleted = 1;
            SwitchRoom();
        }

    }
}
