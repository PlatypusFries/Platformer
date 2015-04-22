using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;
	public float zSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	Vector3 rotation = new Vector3 (xSpeed, ySpeed, zSpeed);
		transform.Rotate (rotation);
	}
}
