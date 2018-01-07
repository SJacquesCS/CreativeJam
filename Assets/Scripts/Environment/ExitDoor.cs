using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    private bool mIsOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
		GetComponent<AudioSource> ().Play ();

        if (collision.gameObject.tag == "mage")
        {
            GetComponent<Animator>().enabled = true;

            GameObject.Find("GameController").GetComponent<GameController>().IncrementRoomCounter();
			GetComponent<Collider2D> ().enabled = false;
        }
    }
}
