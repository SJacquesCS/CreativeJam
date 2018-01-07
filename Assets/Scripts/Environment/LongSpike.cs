using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSpike : MonoBehaviour {

    private bool mHasFallen = false;

    public void Fall()
    {
        if (!mHasFallen)
        {
            mHasFallen = true;

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            StartCoroutine(Vanish());

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("mage").GetComponent<Collider2D>());
        }
    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(7.5f);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mage")
            collision.gameObject.GetComponent<WizardController>().Death();
    }
}
