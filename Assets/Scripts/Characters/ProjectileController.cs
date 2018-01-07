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

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" || other.tag == "Ground")
		{
			Destroy (gameObject, 0.15f);
			if (other.tag == "Enemy")
				other.gameObject.GetComponent<EnemyController>().Death ();
		}
	}
}
