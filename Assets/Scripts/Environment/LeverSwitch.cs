using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour {
    public GameObject mLinkedWaterfall;
    public GameObject mOtherSwitch;

    private bool mIsTriggered = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mage" && !mIsTriggered && Input.GetKeyDown(KeyCode.K))
        {
			GetComponent<AudioSource> ().Play ();
            mIsTriggered = true;

			if (mOtherSwitch) {
				mOtherSwitch.GetComponent<LeverSwitch>().setTriggered();
			}

            transform.localScale = new Vector3(-1, 1, 1);
            transform.position = new Vector3(transform.position.x + 0.75f, transform.position.y);

            if (mLinkedWaterfall)
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
