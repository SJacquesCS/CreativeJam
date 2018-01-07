using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

    public GameObject mDoor;

    private bool mIsTriggered = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Mouse0) && collision.gameObject.tag == "Fireball" && !mIsTriggered)
        {
            mIsTriggered = true;

            GetComponent<Animator>().enabled = true;
            transform.GetChild(0).GetComponent<Light>().enabled = true;

            mDoor.GetComponent<Door>().Open();
        }
    }
}
