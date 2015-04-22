using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

    public float xDistance;
    public float yDistance;
    public float zDistance;
    public float speed;
    bool returning = false;
    Vector3 originPosition;
    Vector3 targetPosition;

	// Use this for initialization
	void Start () {
        originPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPosition = new Vector3(transform.position.x + xDistance, transform.position.y + yDistance, transform.position.z + zDistance);
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if (!returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        if ( transform.position == targetPosition )
        {
            returning = true;
        }

        if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, originPosition, step);
        }
        if (transform.position == originPosition)
        {
            returning = false;
        }
	}
}
