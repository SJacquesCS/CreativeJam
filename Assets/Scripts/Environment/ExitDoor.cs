using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    public GameObject mStageController;

    private bool mIsOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mage")
        {
            GetComponent<Animator>().enabled = true;

            GameObject.Find("GameController").GetComponent<GameController>().IncrementRoomCounter();
        }
    }
}
