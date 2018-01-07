using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private bool mOpening = false;

    private Vector3 mDirection;

	void Update () {
        if (mOpening)
            transform.Translate(mDirection * Time.deltaTime * 2, Space.World);
	}

    public void Open(Vector3 direction)
    {
        mOpening = true;
        mDirection = direction;
		GetComponent<AudioSource> ().Play ();
    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
