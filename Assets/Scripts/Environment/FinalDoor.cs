using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
