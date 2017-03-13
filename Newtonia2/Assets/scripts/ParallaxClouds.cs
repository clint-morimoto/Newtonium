using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxClouds : MonoBehaviour {

    public float backgoundSize;
    public float parallaxSpeed;  // sets the (reduced) speed of the parallax scrolling background...
    public bool /*scrolling, */ parallax;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;  // fetch our current Camera.
        lastCameraX = cameraTransform.position.x;

        layers = new Transform[transform.childCount];  // we assign to the layers array, the childCount of our clouds gameobject (these are the 6 cloud background sprites).
        // Actually fill the layers array with a for loop:
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;  // set rightIndex to point at the last object in our layers array.

	}
	
	// Update is called once per frame
	void Update () {

        if (parallax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;  // we have deltaX as the difference...
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCameraX = cameraTransform.position.x;

        //if (scrolling)
        //{
            if (cameraTransform.position.x < layers[leftIndex].transform.position.x + viewZone)
            {
                ScrollLeft();
            }
            if (cameraTransform.position.x > layers[rightIndex].transform.position.x - viewZone)
            {
                ScrollRight();
            }
        //}
    }

    // We need TWO functions to controll parallax scrolling: ScrollLeft() and ScrollRight():
    // They will respectively check if we are moving too far down the left or right side.
    // Called in Update() function...
    private void ScrollLeft()
    {
        int lastRight = rightIndex;  // we need to keep a pointer towards our last index...
        // if we are going too far down the left side, we need to take the last image from the right side, and place it on the left side...
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgoundSize);  // we do - backgroundSize because we are going towards the left.

        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;  // we need to keep a pointer towards our last index...
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgoundSize);  // we do + backgroundSize because we are going towards the RIGHT.

        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;  // reset leftIndex if it reached the end of layers.Length.
        }
    }
}
