using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour {
    public GameObject mLinkedWaterfall;
    public GameObject mOtherSwitch;

    private bool mIsTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mage" && !mIsTriggered)
        {
            mIsTriggered = true;

            mOtherSwitch.GetComponent<LeverSwitch>().setTriggered();

            transform.Rotate(new Vector3(0, 180));
            transform.position = new Vector3(transform.position.x + 0.75f, transform.position.y);

            mLinkedWaterfall.GetComponent<Waterfall>().Die();
        }
    }

    public void setTriggered()
    {
        mIsTriggered = true;

        transform.Rotate(new Vector3(0, 180));
        transform.position = new Vector3(transform.position.x + 0.75f, transform.position.y);
    }
}
