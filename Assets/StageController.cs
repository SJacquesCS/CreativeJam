using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    public GameObject mImage;

    private bool mIsDead = false;
    private float mAlpha = 0;

    public void died()
    {
        mIsDead = true;
    }

    private void Update()
    {
        if (mIsDead && mAlpha <= 255)
        {
            float r = mImage.GetComponent<SpriteRenderer>().color.r;
            float g = mImage.GetComponent<SpriteRenderer>().color.g;
            float b = mImage.GetComponent<SpriteRenderer>().color.b;

            Debug.Log(mAlpha);

            mImage.GetComponent<SpriteRenderer>().color = new Color(r, g, b, mAlpha++);
        }
    }
}
