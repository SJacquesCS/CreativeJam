using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {

    public GameObject mSpike;

    private bool mIsTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mage" && !mIsTriggered)
        {
            mIsTriggered = true;

            mSpike.GetComponent<LongSpike>().Fall();
        }
    }
}
