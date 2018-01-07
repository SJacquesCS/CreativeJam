using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
	public float mSpeed;

    private float mParticleSize = 1f;
    private float mLightAngle = 70f;
	private float mDirection;

    private void Update()
    {
        mLightAngle -= 0.35f;
        mParticleSize -= 0.005f;

        transform.GetChild(0).GetComponent<Light>().spotAngle = mLightAngle;
        transform.GetChild(1).GetComponent<ParticleSystem>().startSize = mParticleSize;
    }

    public void SendProjectile(bool facingRight)
	{
		if (facingRight)
			mDirection = 1;
		else
			mDirection = -1;

		GetComponent<Rigidbody2D>().velocity = transform.right * mSpeed * mDirection;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ground")
		{
			Destroy (gameObject, 0.15f);
<<<<<<< HEAD

			if (other.gameObject.tag == "Enemy")
				other.gameObject.GetComponent<EnemyController>().Death ();
=======
			if (other.tag == "Enemy")
				other.gameObject.GetComponent<EnemyController>().DecrementHP ();
>>>>>>> 5559cef110946cb32760809f43bb69ff7bfd7c20
		}

        if (other.gameObject.tag == "Fireball")
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
	}
}
