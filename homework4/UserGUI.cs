using baseCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;


public class UserGUI : MonoBehaviour
{

    public bool isgameover = false;

    roundController round;


    // Use this for initialization
    void Start()
    {
        round = (roundController)Director.getInstance().currentSceneController;
    }

    // Update is called once per frame
    void Update()
    {
        if (round.status == "running")
            check();
    }

    void check()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mp = Input.mousePosition;
            Camera ca = Camera.main;
            Ray ray = ca.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ((roundController)Director.getInstance().currentSceneController).hitDisk(hit.transform.gameObject);
            }
        }
    }

    private void OnGUI()
    {
        string buttontext;
        GUI.Box(new Rect(15, 15, 120, 75), "");
        GUI.Label(new Rect(15, 15, 120, 25), "status: " + round.status);
        GUI.Label(new Rect(15, 40, 120, 25), "score: " + round.scorecontroll.getscore());
        GUI.Label(new Rect(15, 65, 120, 25), "level: " + round.roundlever);
        if (round.status == "running")
            buttontext = "pause";
        else if (round.status == "gameover")
            buttontext = "start";
        else
            buttontext = "go on";
        if (GUI.Button(new Rect(15, 95, 120, 30), buttontext))
        {
            if (buttontext == "start")
            {
                round.status = "running";
                round.reset();
            }
            else if (buttontext == "go on")
                round.status = "running";
            else
                round.status = "pause";
        }
        if (GUI.Button(new Rect(15, 135, 120, 30), "reset"))
        {

            round.status = "running";
            round.reset();
        }

    }
}
