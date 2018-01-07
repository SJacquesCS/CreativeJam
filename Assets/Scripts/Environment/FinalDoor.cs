using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour {

    private bool mIsOpen = false;
    private bool mIsUnlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mage" && mIsUnlocked)
            GetComponent<Animator>().enabled = true;
    }

    public void UnlockDoor()
    {
		GetComponent<AudioSource> ().Play ();
        mIsUnlocked = true;

        StartCoroutine(VictoryTransition());
    }

    IEnumerator VictoryTransition()
    {
        yield return new WaitForSeconds(5);

        GameObject.Find("GameController").GetComponent<GameController>().ResetRoomCounter();

        SceneManager.LoadScene(7);
    }
}
