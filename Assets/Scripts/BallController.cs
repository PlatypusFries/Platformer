using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	bool isGrounded = true;
	Vector3 spawnPoint;
	public float killZ;

	void Update ()
	{
		float x = Input.GetAxis( "Horizontal" ) * moveSpeed * Time.deltaTime;
		float z = Input.GetAxis( "Vertical" ) * moveSpeed * Time.deltaTime;

		Vector3 force = new Vector3( x, 0f, z );

		if (Input.GetButtonDown ("Jump") && isGrounded)
		{
			force.y = jumpSpeed;
		}

		rigidbody.AddForce( force );

		if (transform.position.y < killZ)
		{
			transform.position = spawnPoint;
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}

	void OnTriggerEnter(Collider trigger)
	{
		if (trigger.CompareTag("Coin"))
		{
			trigger.gameObject.SetActive(false);
			ScoreTracker.instance.AddScore(10);
		}
		if (trigger.CompareTag("Checkpoint"))
		{
			spawnPoint = trigger.transform.position;
			trigger.gameObject.SetActive(false);
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
        	if (collision.collider.CompareTag("Ground"))
            {
            	isGrounded = false;
                this.gameObject.transform.parent = null;
            }
            
        }
	}
}
