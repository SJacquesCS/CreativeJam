using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject panel;

	void Start () {
        StartCoroutine(StageStart());
	}

    IEnumerator StageStart()
    {
        yield return new WaitForSeconds(2);

        panel.GetComponent<Panel>().Phade();
    }
}
