using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireballController : MonoBehaviour
{
    public float mSpeed;

    public ParticleSystem mParticles;
    public ParticleSystem mBurst;

    private float mDelay = 1f;
    private bool mIsShrunk = false;
    private bool mIsDead = false;

    private Vector2 mScale = new Vector2(1f, 1f);
    private float mRadius = 0.4f;
    private float mSpotAngle = 70.0f;
    private float mParticleSize = 1;

	void Awake()
	{
		Cursor.visible = false;

		if (GameObject.FindGameObjectWithTag("mage"))
			Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("mage").GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

	void Update ()
	{
        if (!mIsDead)
        {
            Move();
            if (!mIsShrunk)
                Burst();
            Shrink();
        }
        else
        {
            mScale -= new Vector2(0.025f, 0.025f);
            mRadius -= 0.01f;
            mSpotAngle -= 1.85f;
            mParticleSize -= 0.01f;

            if (mScale.x >= 0)
                transform.GetChild(3).transform.localScale = mScale;

            if (mRadius >= 0)
                transform.GetComponent<CircleCollider2D>().radius = mRadius;

            if (mSpotAngle >= 0)
                transform.GetChild(1).GetComponent<Light>().spotAngle = mSpotAngle;

            if (mParticleSize >= 0)
            {
                mParticles.startSize = mParticleSize;
                mBurst.startSize = mParticleSize;
            }
            else
                Destroy(gameObject);
        }
	}

	void Move()
	{
		Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distances = new Vector2(mouseLocation.x - transform.position.x, mouseLocation.y - transform.position.y);

        if (distances.magnitude > 0.001f)
            GetComponent<Rigidbody2D>().AddForce(distances.normalized * 0.001f * mSpeed);

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
                mScale = new Vector2(1, 1);
                mRadius = 0.4f;
                mSpotAngle = 70;
                mParticleSize = 1;
            }
            else
            {
                mScale = new Vector2(0.5f, 0.5f);
                mRadius = 0.2f;
                mSpotAngle = 35;
                mParticleSize = 0.5f;
            }

            transform.GetChild(3).transform.localScale = mScale;
            transform.GetComponent<CircleCollider2D>().radius = mRadius;
            transform.GetChild(1).GetComponent<Light>().spotAngle = mSpotAngle;
            mParticles.startSize = mParticleSize;
            mBurst.startSize = mParticleSize;

            mIsShrunk = !mIsShrunk;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Waterfall")
        {
            mIsDead = true;
            StartCoroutine(Vanish());
        }
    }

    public bool checkShrunk()
    {
        return mIsShrunk;
    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
