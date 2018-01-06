using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour {

    private bool mDying = false;

    public void Die()
    {
        mDying = true;

        StartCoroutine(Vanish());
    }

    void Update()
    {
        if (mDying == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5);
        }
    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
