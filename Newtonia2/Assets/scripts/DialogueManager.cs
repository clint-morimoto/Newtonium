using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * With this script, we want to know:
 *      What our dialogue box object is, so we can attach this script to it
 *      What the DIALOGUE BOX is, so we can TURN IT ON AND OFF.
 *      What are text object is, so we can make changes to it...
 */

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public Text iText;

    public bool dialogueActive;  // This keeps track of whether the dialogue box should be displayed, or not.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
            dBox.SetActive(false);
            dialogueActive = false;
        }
	}

    // NEW FUNCTION: sends the text that we want to say into this function, to read it...
    public void ShowBox(string dialogue)
    {
        // Turn on our dialogue box:
        dialogueActive = true;
        dBox.SetActive(true);

        dText.text = dialogue;  // assign our dialogue text into our text object in Unity.
    }
}
