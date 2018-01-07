using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float mSpeed;

    public ParticleSystem mParticles;
    public ParticleSystem mBurst;

    private float mDelay = 1f;

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
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            mParticles.startSize = 0.5f;
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            mParticles.startSize = 1;
        }
    }
}
