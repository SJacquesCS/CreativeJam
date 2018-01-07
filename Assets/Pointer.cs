using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

	void Update () {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = transform.position.z - Camera.main.transform.position.z;

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
