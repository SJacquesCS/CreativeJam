using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour {
    public GameObject mLinkedWaterfall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mage")
        {
            transform.Rotate(new Vector3(0, 180));
            transform.position = new Vector3(transform.position.x + 0.75f, transform.position.y);

            mLinkedWaterfall.GetComponent<Waterfall>().Die();
        }
    }
}
