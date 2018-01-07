using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplatform : MonoBehaviour {

    private void Awake()
    {
        StartCoroutine(MovePlat());
    }

    IEnumerator MovePlat()
    {
        yield return new WaitForSeconds(5);

        GameObject.Find("Door").GetComponent<Door>().Open(Vector3.left);
    }
}
