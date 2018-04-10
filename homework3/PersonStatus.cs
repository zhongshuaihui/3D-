using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class PersonStatus : MonoBehaviour {

    private Vector3 originalpos;
    public bool onboatleft, onboatright;
    public bool onleftbank, onrightbank;
    private GameJudge gamejudge;
    public Actionmanager addAction;
    public float Person_speed = 0.5f;
    public mainController gamestatus;

    // Use this for initialization
    void Start () {
        originalpos = this.transform.position;
        onboatleft = false;
        onboatright = false;
        onleftbank = false;
        onrightbank = true;
        gamejudge = mainController.getInstance() as GameJudge;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void persongetonboat(bool boatatleft,bool leftseat)
    {
        if (leftseat)
        {
            if (boatatleft)
                this.transform.position = location.boatLeft_1_loc;
            else
                dividethepos_setmove(this.transform.position, true);
            onboatleft = true;
        }
        else
        {
            if (boatatleft)
                this.transform.position = location.boatLeft_2_loc;
            else
                this.transform.position = location.boatRight_2_loc;
            onboatright = true;
        }
        onleftbank = false;
        onrightbank = false;
        if(this.tag.Equals("Priest"))
        {
            gamejudge.change_boat_priests_num(ifadd.add);
            gamejudge.change_bank_priests_num(boatatleft, ifadd.sub);
        }
        else
        {
            gamejudge.change_boat_devils_num(ifadd.add);
            gamejudge.change_bank_devils_num(boatatleft, ifadd.sub);
        }
    }

    public void persongetoffboat(bool boatatleft)
    {
        if (boatatleft)
        {
            this.transform.position = new Vector3(-originalpos.x, originalpos.y, originalpos.z);
            onleftbank = true;
        }
        else
        {
            this.transform.position = originalpos;
            onrightbank = true;
        }
        onboatleft = false;
        onboatright = false;
        if (this.tag.Equals("Priest"))
        {
            gamejudge.change_boat_priests_num(ifadd.sub);
            gamejudge.change_bank_priests_num(boatatleft, ifadd.add);
        }
        else
        {
            gamejudge.change_boat_devils_num(ifadd.sub);
            gamejudge.change_bank_devils_num(boatatleft, ifadd.add);
        }
    }

    void dividethepos_setmove(Vector3 target,bool isgeton)
    {
        Vector3[] dividedpos = new Vector3[2];
        float[] speedset = new float[2];

        if (isgeton)
        {
            dividedpos[0] = new Vector3(target.x, this.transform.position.y, 0);
            dividedpos[1] = target;
        }
        else
        {
            dividedpos[0] = new Vector3(this.transform.position.x, target.y, 0);
            dividedpos[1] = target;
        }

        speedset[0] = Person_speed;
        speedset[1] = Person_speed;

        addAction.groupmoving(this.gameObject, dividedpos, speedset);
        gamestatus.setObjMoving(movement.moving);
    }
}
