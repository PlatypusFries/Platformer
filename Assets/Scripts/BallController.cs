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

		if (Input.GetButtonDown ("Jump") && isGrounded)
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

	void OnCollisionStay(Collision collision)
	{
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                if (collision.collider.CompareTag("Ground") && this.collider)
                {
                    isGrounded = true;
                    this.gameObject.transform.parent = collision.gameObject.transform;
                }
            }
        }
	}

	void OnCollisionExit(Collision collision)
	{
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                if (collision.collider.CompareTag("Ground"))
                {
                    isGrounded = false;
                    this.gameObject.transform.parent = null;
                }
            }
        }
	}
}
