using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserInterface : MonoBehaviour {

    UserActions myActions;
    float width = 150;
    float heigth = 80;

	// Use this for initialization
	void Start () {
        myActions = mainController.getInstance() as UserActions;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(75,250,width,heigth),"Priests Geton"))
        {
            myActions.priests_get_on();
        }
        if(GUI.Button(new Rect(225, 250, width, heigth), "Priests Getoff"))
        {
            myActions.priests_get_off();
        }
        if(GUI.Button(new Rect(375, 250, width, heigth), "Go"))
        {
            myActions.boatmove();
        }
        if(GUI.Button(new Rect(525, 250, width, heigth), "Devils Geton"))
        {
            myActions.devils_get_on();
        }
        if(GUI.Button(new Rect(675, 250, width, heigth), "Devils Getoff"))
        {
            myActions.devils_get_off();
        }
    }
}
