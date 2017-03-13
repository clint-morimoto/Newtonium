using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to control the hovering vertical movement of CASCopter.

public class Hovering : MonoBehaviour {

    public GameObject followTarget;  // tracks the follow point that moves between top and bottom

    public Transform top;  // stores the top position of the movement path

    public Transform bottom;  // store the bottom position

    public float speed;

    private Vector3 currentTarget;  // The position (vector point) that we want to move towards. 

	// Use this for initialization
	void Start () {
        currentTarget = top.position;
	}
	
	// Update is called once per frame
	void Update () {
        followTarget.transform.position = Vector3.MoveTowards(followTarget.transform.position, currentTarget, speed * Time.deltaTime);

        if (followTarget.transform.position == top.position)
        {
            currentTarget = bottom.position;
        }
        if (followTarget.transform.position == bottom.position)
        {
            currentTarget = top.position;
        }
    }
}
