using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
	public GameObject target;

	Vector3 offset; //position relative to target object
	
	// Use this for initialization
	void Start ()
	{
		offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = target.transform.position + offset;
	}
}
