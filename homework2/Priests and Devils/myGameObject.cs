using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class myGameObject : MonoBehaviour
{

    public List<GameObject> Priests, Devils;
    public GameObject boat, leftbank, rightbank;
    private BoatBehaviour myboatbehaviour;

    // Use this for initialization
    void Start()
    {
        Priests = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject priests = GameObject.CreatePrimitive(PrimitiveType.Cube);
            priests.name = "Priest" + (i + 1);
            priests.tag = "Priest";
            priests.GetComponent<MeshRenderer>().material.color = Color.white;
            priests.AddComponent<PersonStatus>();
            priests.transform.localScale = new Vector3(1, 1.5f, 1);
            Priests.Add(priests);
        }
        Priests[0].transform.position = location.priests_1_loc;
        Priests[1].transform.position = location.priests_2_loc;
        Priests[2].transform.position = location.priests_3_loc;

        Devils = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject devils = GameObject.CreatePrimitive(PrimitiveType.Cube);
            devils.name = "Devils" + (i + 1);
            devils.tag = "Devil";
            devils.GetComponent<MeshRenderer>().material.color = Color.red;
            devils.AddComponent<PersonStatus>();
            devils.transform.localScale = new Vector3(1, 1.5f, 1);
            Devils.Add(devils);
        }
        Devils[0].transform.position = location.devils_1_loc;
        Devils[1].transform.position = location.devils_2_loc;
        Devils[2].transform.position = location.devils_3_loc;

        boat = GameObject.CreatePrimitive(PrimitiveType.Cube);
        boat.name = "Boat";
        boat.AddComponent<BoatBehaviour>();
        myboatbehaviour = boat.GetComponent<BoatBehaviour>();
        boat.GetComponent<MeshRenderer>().material.color = Color.yellow;
        boat.transform.localScale = new Vector3(3, 1, 1);
        boat.transform.position = location.boat_right_loc;

        leftbank = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftbank.name = "BankLeft";
        leftbank.GetComponent<MeshRenderer>().material.color = Color.green;
        leftbank.transform.Rotate(new Vector3(0, 0, 90));
        leftbank.transform.localScale = new Vector3(1, 8, 1);
        leftbank.transform.position = location.bank_left_loc;

        rightbank = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightbank.name = "BankRight";
        rightbank.GetComponent<MeshRenderer>().material.color = Color.green;
        rightbank.transform.Rotate(new Vector3(0, 0, 90));
        rightbank.transform.localScale = new Vector3(1, 8, 1);
        rightbank.transform.position = location.bank_right_loc;
        rightbank.transform.position = location.bank_right_loc;

        mainController.getInstance().setGameObject(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void boatmove()
    {
        myboatbehaviour.setboatmove();
    }

    public void devils_get_on()
    {
        if (myboatbehaviour.ismoving)
            return;
        if (myboatbehaviour.boatloc())
        {
            for (int i = 0; i < Devils.Count; i++)
            {
                if (Devils[i].GetComponent<PersonStatus>().onleftbank)
                {
                    ifemptyseat(false, i, direction.left);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < Devils.Count; i++)
            {
                if (Devils[i].GetComponent<PersonStatus>().onrightbank)
                {
                    ifemptyseat(false, i, direction.right);
                    break;
                }
            }
        }
    }

    public void devils_get_off()
    {
        if (myboatbehaviour.ismoving)
            return;
        if (myboatbehaviour.boatloc())
        {
            for(int i = Devils.Count - 1; i >= 0; i--)
            {
                if (ifpeopleonboat(false, i, direction.left))
                    break;
            }
        }
        else
        {
            for (int i = Devils.Count - 1; i >= 0; i--)
            {
                if (ifpeopleonboat(false, i, direction.right))
                    break;
            }
        }
    }

    public void priests_get_on()
    {
        if (myboatbehaviour.ismoving)
            return;
        if (myboatbehaviour.boatloc())
        {
            for (int i = 0; i < Priests.Count; i++)
            {
                if (Priests[i].GetComponent<PersonStatus>().onleftbank)
                {
                    ifemptyseat(true, i, direction.left);
                    break;
                }
            }
        }
        else
        {
            for(int i = 0; i < Priests.Count; i++)
            {
                if (Priests[i].GetComponent<PersonStatus>().onrightbank)
                {
                    ifemptyseat(true, i, direction.right);
                    break;
                }
            }
        }
    }

    public void priests_get_off()
    {
        if (myboatbehaviour.ismoving)
            return;
        if (myboatbehaviour.boatloc())
        {
            for (int i = Priests.Count - 1; i >= 0; i--)
            {
                if (ifpeopleonboat(true, i, direction.left))
                    break;
            }
        }
        else
        {
            for (int i = Priests.Count - 1; i >= 0; i--)
            {
                if (ifpeopleonboat(true, i, direction.right))
                    break;
            }
        }
    }

    void ifemptyseat(bool isPriests,int index,bool boatDir)
    {
        if (myboatbehaviour.leftseatempty())
            letpersongetonboat(isPriests, index, boatDir, direction.left);
        else if(myboatbehaviour.rightseatempty())
            letpersongetonboat(isPriests, index, boatDir, direction.right);
    }

    void letpersongetonboat(bool isPriests,int index,bool boatDir,bool seatDir)
    {
        if (isPriests)
        {
            Priests[index].GetComponent<PersonStatus>().persongetonboat(boatDir, seatDir);
            Priests[index].transform.parent = boat.transform;
        }
        else
        {
            Devils[index].GetComponent<PersonStatus>().persongetonboat(boatDir, seatDir);
            Devils[index].transform.parent = boat.transform;
        }
        myboatbehaviour.haveaseat(seatDir);
    }

    bool ifpeopleonboat(bool ispriests,int i,bool boatDir)
    {
        if(ispriests)
        {
            if(Priests[i].GetComponent<PersonStatus>().onboatleft || Priests[i].GetComponent<PersonStatus>().onboatright)
            {
                myboatbehaviour.leaveseat(Priests[i]. GetComponent<PersonStatus>().onboatleft);
                Priests[i].GetComponent<PersonStatus>().persongetoffboat(boatDir);
                Priests[i].transform.parent = boat.transform.parent;
                return true;
            }
            return false;
        }
        else
        {
            if (Devils[i].GetComponent<PersonStatus>().onboatleft || Devils[i].GetComponent<PersonStatus>().onboatright)
            {
                myboatbehaviour.leaveseat(Devils[i].GetComponent<PersonStatus>().onboatleft);
                Devils[i].GetComponent<PersonStatus>().persongetoffboat(boatDir);
                Devils[i].transform.parent = boat.transform.parent;
                return true;
            }
            return false;
        }
    }
}