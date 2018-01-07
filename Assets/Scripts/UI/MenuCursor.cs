using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCursor : MonoBehaviour
{
	public float speed;

	void Awake()
	{
		Cursor.visible = false;
	}

	void Update ()
	{
		Move ();
	}

	void Move()
	{
		Vector3 mouselocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float xDist = mouselocation.x - transform.position.x;
		float yDist = mouselocation.y - transform.position.y;

		transform.Translate(new Vector3(xDist, yDist) * Time.deltaTime * speed);
	}
}
