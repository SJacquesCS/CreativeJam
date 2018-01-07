using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public float mSpeed;
	bool mFacingRight = true;
	bool mWalking = true;
	bool mDead = false;

	Animator mAnimator;
	Transform mSpriteChild;

	void Awake ()
	{
		mAnimator = GetComponentInChildren<Animator>();
		mSpriteChild = GetComponentInChildren<SpriteRenderer>().transform;
	}

	void Update ()
	{
		if (mFacingRight)
			FaceDirection (new Vector2 (1f, 0f));
		else
			FaceDirection (new Vector2 (-1f, 0f));

		if (!mDead)
			Move ();
		
		mAnimator.SetBool("IsWalking", mWalking);
	}

	void Move()
	{
		transform.Translate (new Vector3 (mSpeed, 0f, 0f) * Time.deltaTime);
	}

	void FaceDirection(Vector2 direction)
	{
		Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back); 
		mSpriteChild.rotation = rotation3D;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Patrol Collider" || col.gameObject.tag == "mage")
		{
			if (col.gameObject.tag == "mage")
			{
				col.gameObject.GetComponent<WizardController> ().Death ();
			}

			mSpeed *= -1f;
			if (mFacingRight)
				mFacingRight = false;
			else
				mFacingRight = true;
		}
	}

	public void Death ()
	{
		mDead = true;
		mAnimator.SetTrigger ("IsDead");
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("mage").GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Fireball").GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Destroy (gameObject, 2f);
	}
}
