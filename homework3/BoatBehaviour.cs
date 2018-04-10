using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class BoatBehaviour : MonoBehaviour {

    private Vector3 moveDir = new Vector3(-0.1f, 0, 0);
    public bool ismoving;
    public bool atleftside;
    public bool leftEmpty, rightEmpty;
    public Actionmanager addAction;
    private GameJudge gamejudge;
    
    public float Boat_speed = 1;

    private void Awake()
    {
        gamejudge = mainController.getInstance() as GameJudge;
    }

    // Use this for initialization
    void Start () {
        ismoving = false;
        atleftside = direction.right;
        leftEmpty = true;
        rightEmpty = true;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (ismoving)
        {
            if (!ismovingtoedge())
            {
                this.transform.Translate(moveDir);
            }
        }
    }

    private bool ismovingtoedge()
    {
        if (moveDir.x < 0 && this.transform.position.x <= location.boat_left_loc.x)
        {
            ismoving = false;
            atleftside = direction.left;
            gamejudge.ifgg(direction.left);
            moveDir = new Vector3(-moveDir.x, 0, 0);
            return true;
        }
        else if (moveDir.x > 0 && this.transform.position.x >= location.boat_right_loc.x)
        {
            ismoving = false;
            atleftside = direction.right;
            gamejudge.ifgg(direction.right);
            moveDir = new Vector3(-moveDir.x, 0, 0);
            return true;
        }
        else
            return false;
    }

    public void setboatmove()
    {
        addAction.singlemoving(this.gameObject, location.boat_right_loc,Boat_speed);
    }

    public bool boatloc()
    {
        return atleftside;
    }

    public bool leftseatempty()
    {
        return leftEmpty;
    }

    public bool rightseatempty()
    {
        return rightEmpty;
    }

    public void haveaseat(bool isleft)
    {
        if (isleft)
            leftEmpty = false;
        else
            rightEmpty = false;
    }

    public void leaveseat(bool isleft)
    {
        if (isleft)
            leftEmpty = true;
        else
            rightEmpty = true;
    }
}
