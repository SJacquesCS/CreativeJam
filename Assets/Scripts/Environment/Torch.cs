using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

    public GameObject mDoor;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().enabled = true;
            transform.GetChild(0).GetComponent<Light>().enabled = true;

            mDoor.GetComponent<Door>().Open();
        }
    }
}
