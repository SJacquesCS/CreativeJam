using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour {
    public GameObject mLinkedDoor;

    public void ActivateSwitch()
    {
        GetComponent<Animator>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActivateSwitch();
    }
}
