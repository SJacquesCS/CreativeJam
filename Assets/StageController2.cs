using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController2 : MonoBehaviour {

    public GameObject mMovingFloor;

	void Start () {
        StartCoroutine(SlideFloor());
	}

    IEnumerator SlideFloor()
    {
        yield return new WaitForSeconds(5f);

        mMovingFloor.GetComponent<Door>().Open(Vector3.left);
    }
}
