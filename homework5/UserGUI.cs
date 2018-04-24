using baseCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

public class UserGUI : MonoBehaviour
{

    public bool isgameover = false;
    public bool showtext = false;
    public GameObject bullet;
    public float speed = 10f;
    public ParticleSystem explosion;

    roundController round;


    // Use this for initialization
    void Start()
    {
        round = (roundController)Director.getInstance().currentSceneController;
        bullet = Instantiate(Resources.Load<GameObject>("Prefabs/bullet")) as GameObject;
        explosion = Instantiate(Resources.Load<ParticleSystem>("Prefabs/Particle System")) as ParticleSystem;
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
            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(ray.direction * speed, ForceMode.Impulse);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                explosion.transform.position = hit.transform.position;
                explosion.GetComponent<Renderer>().material.color = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
                explosion.Play();
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
        if(round.roundlever == 4 && showtext == false)
        {
            GameObject Canvas = Camera.Instantiate(Resources.Load("Prefabs/Canvas")) as GameObject;
            GameObject GameText = Camera.Instantiate(Resources.Load("Prefabs/Text"), Canvas.transform) as GameObject;
            GameText.GetComponent<Text>().text = "Game Over!";
            showtext = true;
        }
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
