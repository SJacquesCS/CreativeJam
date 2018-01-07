using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    public GameObject mImage;
    public GameObject mGameController;

    private bool mIsDead = false;
    private float mAlpha = 100f;

    public void died()
    {
        mIsDead = true;
    }

    private void Update()
    {
        if (mIsDead)
        mImage.GetComponent<CanvasRenderer>().SetAlpha(mAlpha);
    }
}
