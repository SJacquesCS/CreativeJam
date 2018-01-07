using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackener : MonoBehaviour {

    private bool mFade = false;
    private float mAlpha = 0;

	void Start () {
		
	}

	void Update () {
        if (mFade) {
            float r = GetComponent<SpriteRenderer>().color.r;
            float g = GetComponent<SpriteRenderer>().color.g;
            float b = GetComponent<SpriteRenderer>().color.b;

            GetComponent<SpriteRenderer>().color = new Color(r, g, b, mAlpha);

            mAlpha += 0.01f;

            if (mAlpha >= 255)
                mFade = false;
        }
	}

    public void Fade()
    {
        mFade = true;
    }
}
