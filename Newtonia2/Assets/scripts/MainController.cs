using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    // Initialize variables that control or modify player movement:
    public float moveSpeed;
    private Rigidbody2D mainRigidBody;  // assigns the rigidbody2d we made for nMain to this script...

    // Any object in Unity has a position, which is stored by a Transform data type:
    public Transform groundCheck;

    // checks where the ground is (relative to a radial distance...):
    public float groundCheckRadius;

    // Assigns ground to the appropriate layer:
    public LayerMask whatIsGround;  // note that you CAN assign multiple layers to this variable.

    public bool isGrounded;  // check whether player is on ground (or not)

    private Animator mainAnim;  // like RigidBody2D class, we must assign our animator to this script.
    
    // Use this for initialization
	void Start () {
        mainRigidBody = GetComponent<Rigidbody2D>();
        mainAnim = GetComponent<Animator>();

        mainRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;  // YES!
	}
	
	// Update is called once per frame
	void Update () {

        // Check to see if player is in contact with whatIsGround layermask:
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            // make player move right:
            mainRigidBody.velocity = new Vector3(moveSpeed, mainRigidBody.velocity.y, 0f);
            // make the sprite face the right way when moving in this direction:
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            mainRigidBody.velocity = new Vector3(-moveSpeed, mainRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else
        {
            mainRigidBody.velocity = new Vector3(0f, mainRigidBody.velocity.y, 0f);
        }

        // If we wanted a jump action for player, code it here:
        //if (Input.GetButtonDown(...)) {}

        mainAnim.SetFloat("speed", Mathf.Abs(mainRigidBody.velocity.x));  // note that we want ANY nonzero value of speed; must convert negative speed to positive speed, so we use Mathf.Abs() to get the abs value...
        mainAnim.SetBool("grounded", isGrounded);
    }
}
