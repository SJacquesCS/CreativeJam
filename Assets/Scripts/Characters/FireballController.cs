using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float mSpeed;

    public ParticleSystem mParticles;
    public ParticleSystem mBurst;

    private float mDelay = 1f;
    private bool mIsShrunk = false;

	void Awake()
	{
		Cursor.visible = false;

		if (GameObject.FindGameObjectWithTag("mage"))
			Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("mage").GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

	void Update ()
	{
		Move();
        Burst();
        Shrink();
	}

	void Move()
	{
		Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distances = new Vector2(mouseLocation.x - transform.position.x, mouseLocation.y - transform.position.y);

        if (distances.magnitude > 0.5f)
            GetComponent<Rigidbody2D>().AddForce(distances.normalized * 0.01f);

        GetComponent<Rigidbody2D>().velocity = new Vector2(
            Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x, -5f, 5f),
            Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.y, -5f, 5f)
        );
    }

    void Burst()
    {
        if (Input.GetKey(KeyCode.Mouse0) && mDelay <= 0f)
        {
            mBurst.Play();
            mDelay = 1f;
        }

        if (mDelay > 0)
        {
            mDelay -= 0.05f;
        }
    }

    void Shrink()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (mIsShrunk)
            {
                transform.GetChild(3).transform.localScale = new Vector2(1f, 1f);
                transform.GetComponent<CircleCollider2D>().radius = 0.4f;
                transform.GetChild(1).GetComponent<Light>().spotAngle = 70f;
                mParticles.startSize = 1f;
            }
            else
            {
                transform.GetChild(3).transform.localScale = new Vector2(0.5f, 0.5f);
                transform.GetComponent<CircleCollider2D>().radius = 0.2f;
                transform.GetChild(1).GetComponent<Light>().spotAngle = 35f;
                mParticles.startSize = 0.5f;
            }

            mIsShrunk = !mIsShrunk;
        }
    }
}
