using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasController : MonoBehaviour {

    //  Use this to find the script attached to the main character:
    private MainController mainPlayer;
    public GameObject followTarget;

    public float speed;

    public LayerMask playerLayer;

    // Use these next two variables to track the range that determines where CasCopter will STOP following Main.
    public float mainRange;
    public bool mainInRange;

	// Use this for initialization
	void Start () {
        mainPlayer = FindObjectOfType<MainController>();
	}
	
	// Update is called once per frame
	void Update () {

        mainInRange = Physics2D.OverlapCircle(transform.position, mainRange, playerLayer);

        if (!mainInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, followTarget.transform.position, speed * Time.deltaTime);
            //transform.position = Vector3.SmoothDamp(transform.position, mainPlayer.transform.position, speed * Time.deltaTime, smoothTime);
        }

        if (transform.position.x - followTarget.transform.position.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (transform.position.x - followTarget.transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, mainRange);
    }
}
