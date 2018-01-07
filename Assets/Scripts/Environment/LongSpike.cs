using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSpike : MonoBehaviour {

    public void Fall()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        StartCoroutine(Vanish());
    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(7.5f);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mage")
            collision.gameObject.GetComponent<WizardController>().Damage();
    }
}
