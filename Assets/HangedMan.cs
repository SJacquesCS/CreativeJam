using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangedMan : MonoBehaviour {

    private float mSilence = 0;

    private void Update()
    {
        if (mSilence > 0)
            mSilence -= 0.01f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fireball" && mSilence <= 0)
        {
            mSilence = 2;
            GetComponent<AudioSource>().Play();
        }
    }
}
