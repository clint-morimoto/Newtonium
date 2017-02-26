using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    // Initialize variables that control or modify player movement:
    public float moveSpeed;
    private Rigidbody2D myRigidBody;

    // Any object in Unity has a position, which is stored by a Transform data type:
    public Transform groundCheck;

    // checks where the ground is (relative to a radial distance...):
    public float groundCheckRadius;

    // Assigns ground to the appropriate layer:
    public LayerMask whatIsGround;  // note that you CAN assign multiple layers to this variable.

    public bool isGrounded;  // check whether player is on ground (or not)
    
    // Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;  // YES!
	}
	
	// Update is called once per frame
	void Update () {

        // Check to see if player is in contact with whatIsGround layermask:
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
        } else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
        } else
        {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
        }

        // If we wanted a jump action for player, code it here:
        //if (Input.GetButtonDown(...)) {}
    }
}
