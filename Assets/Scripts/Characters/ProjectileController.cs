using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
	public float mSpeed;
	private float mDirection;

	public void SendProjectile(bool facingRight)
	{
		if (facingRight)
			mDirection = 1;
		else
			mDirection = -1;

		GetComponent<Rigidbody2D>().velocity = transform.right * mSpeed * mDirection;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			Destroy (gameObject);
		}
	}
}
