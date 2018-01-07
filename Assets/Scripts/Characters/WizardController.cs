using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour {
	
    public float mWalkSpeed;
    public float mRunSpeed;
    public float mJumpForce;

	public Transform mGroundCheck;
    public Transform[] mShotSpawns;
    public LayerMask mGroundLayer;
    public GameObject mFireball;
    public GameObject mShot;
    public float mFireRate;

    private Animator mAnimator;
    private Rigidbody2D mRigidBody2D;
    private Transform mSpriteChild;
    private float kGroundCheckRadius = 0.1f;
    private float mNextFire;
    private bool mFacingRight = false;
    private bool mDead = false;

    private bool mRunning;
    private bool mWalking;
    private bool mGrounded;
    private bool mFalling;
    private bool mFiring;

    void Awake ()
	{
		mAnimator = GetComponentInChildren<Animator>();
        mRigidBody2D = GetComponent<Rigidbody2D>();
        mSpriteChild = transform.Find ("WizardSprite");

		GameObject[] patrolColliders = GameObject.FindGameObjectsWithTag ("Patrol Collider");

		foreach (GameObject col in patrolColliders)
		{
			Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	void Update()
	{
		CheckFalling ();
		CheckGrounded ();

        if (!mDead && Input.GetKey(KeyCode.J) && Time.time > mNextFire)
			StartCoroutine ("Fire");
	}
		
	void FixedUpdate ()
	{
        if (!mDead)
        {
            Move();
            Interact();
            Swap();
        }
        else
            transform.Rotate(Vector3.forward * 2);
		
		mAnimator.SetBool("IsWalking", mWalking);
        mAnimator.SetBool("IsRunning", mRunning);
	}

	void Move ()
	{
		float moveLeft = Input.GetAxisRaw("Left");
		float moveRight = Input.GetAxisRaw ("Right");

		Vector3 directionLeft = new Vector3(moveLeft, 0.0f, 0.0f);
		Vector3 directionRight = new Vector3(moveRight, 0.0f, 0.0f);

		float movementSpeed = mWalkSpeed;

		if (Input.GetKey (KeyCode.LeftShift) && mWalking)
		{
			mRunning = true;
			movementSpeed = mRunSpeed;
		}
		else
			mRunning = false;
		
		if (Input.GetKey (KeyCode.A))
		{
			FaceDirection ((Vector2)directionRight);
			mFacingRight = false;
			transform.position -= directionLeft * movementSpeed * Time.deltaTime;
			mWalking = true;
		}
			
		if (Input.GetKey (KeyCode.D))
		{
			FaceDirection ((Vector2)directionRight);
			mFacingRight = true;
			transform.position += directionRight * movementSpeed * Time.deltaTime;
			mWalking = true;
		}

		if (Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.A) == false)
			mWalking = false;
		
		if (Input.GetKeyDown (KeyCode.Space) && mGrounded)
			mRigidBody2D.AddForce(new Vector2(0.0f, 1.0f) * mJumpForce);
				
	}

	void Jump ()
	{
		if (mGrounded && Input.GetButtonDown("Jump"))
		{
			mRigidBody2D.AddForce(new Vector2(0.0f, 1.0f) * mJumpForce);
		}
	}
	
	void CheckFalling()
    {
        mFalling = mRigidBody2D.velocity.y < 0.0f;
		mAnimator.SetBool("IsFalling", mFalling);
    }

	void FaceDirection(Vector2 direction)
	{
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back); 
        mSpriteChild.rotation = rotation3D;
	}

	void CheckGrounded()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(mGroundCheck.position, kGroundCheckRadius, mGroundLayer);
        foreach(Collider2D col in colliders)
        {
            if(col.gameObject != gameObject)
            {
                mGrounded = true;
				mAnimator.SetBool("IsGrounded", mGrounded);
                return;
            }
        }
		mGrounded = false;
		mAnimator.SetBool("IsGrounded", mGrounded);
	}

	public void Death ()
	{
		mAnimator.SetTrigger ("IsDead");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(50, 150), 300));
        GetComponent<Collider2D>().enabled = false;
		mDead = true;
		Destroy (gameObject, 4f);
	}

	void Interact()
	{

	}

    void Swap()
    {
        if ((Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.Mouse2)) || (Input.GetKey(KeyCode.L) && Input.GetKeyDown(KeyCode.Mouse2)))
        {
            Vector2 fireballPos = mFireball.transform.position;
            mFireball.transform.position = transform.position;
            transform.position = fireballPos;
        }
    }

	IEnumerator Fire()
	{
		GameObject projectile;
		mNextFire = Time.time + mFireRate;

		mFiring = true;
		mAnimator.SetBool("IsFiring", mFiring);

		yield return new WaitForSeconds(0.50f);

		if (mFacingRight)
			projectile = Instantiate(mShot, mShotSpawns[0].position, mShotSpawns[0].rotation) as GameObject;
		else
			projectile = Instantiate(mShot, mShotSpawns[1].position, mShotSpawns[1].rotation) as GameObject;
			
		if (projectile)
			projectile.GetComponent<ProjectileController>().SendProjectile(mFacingRight);

		Destroy (projectile, 3.5f);

		yield return new WaitForSeconds(0.1f);
		mFiring = false;
		mAnimator.SetBool("IsFiring", mFiring);
	}
}
