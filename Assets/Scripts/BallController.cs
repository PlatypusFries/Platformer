using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	bool isGrounded = true;

	void Update ()
	{
		float x = Input.GetAxis( "Horizontal" ) * moveSpeed * Time.deltaTime;
		float z = Input.GetAxis( "Vertical" ) * moveSpeed * Time.deltaTime;

		Vector3 force = new Vector3( x, 0f, z );

		if (Input.GetButton ("Jump") && isGrounded)
		{
			force.y = jumpSpeed * Time.deltaTime;
		}

		rigidbody.AddForce( force );
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			ScoreTracker.instance.AddScore(10);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
			this.gameObject.transform.parent = collision.gameObject.transform;
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = false;
			this.gameObject.transform.parent = null;
		}
	}
}
