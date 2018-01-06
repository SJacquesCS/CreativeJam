using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private bool mOpening = false;

	void Update () {
        if (mOpening)
            transform.Translate(Vector3.up * Time.deltaTime * 2);
	}

    public void Open()
    {
        mOpening = true;


    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
