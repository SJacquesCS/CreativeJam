using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {

    public float mRotationSpeed;
    public float mMoveSpeed;

    public Transform[] mSawPoints;

    private int mCurrentPoint = 1;

	void Update () {
        Vector2 direction = mSawPoints[mCurrentPoint].position - transform.position;

        if (direction.magnitude <= 0.1f)
            mCurrentPoint = (++mCurrentPoint) % 4;

        transform.Translate(direction.normalized * Time.deltaTime * mMoveSpeed, Space.World);

        transform.Rotate(Vector3.back, mRotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mage")
            collision.gameObject.GetComponent<WizardController>().Damage();
    }
}
