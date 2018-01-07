using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {

    private bool mIsFading = false;
    private float fadeCtr = 100f;

    private void Update()
    {
        if (mIsFading = true && GetComponent<CanvasRenderer>().GetAlpha() > 0.000000f)
        {
            GetComponent<CanvasRenderer>().SetAlpha(fadeCtr);
            fadeCtr -= 1f;
        }
    }

    public void Phade()
    {
        mIsFading = true;
    }
}
