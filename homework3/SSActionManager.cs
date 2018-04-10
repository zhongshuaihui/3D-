using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class SSActionManager : MonoBehaviour {

    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    private List<SSAction> waitingAdd = new List<SSAction>();
    private List<int> waitingDelete = new List<int>();

	// Use this for initialization
	protected void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
        foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        foreach(KeyValuePair<int,SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destroy)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if(ac.enable)
            {
                ac.Update();
            }
        }

        foreach(int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
        waitingDelete.Clear();
	}

    public void RunAction(GameObject gameobject,SSAction action, IssActionCallback manager)
    {
        action.gameobject = gameobject;
        action.transform = gameobject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }
}

public class CCActionManager    : SSActionManager, IssActionCallback
{

    public mainController scene;

    public void singlemoving(GameObject source, Vector3 target, float speed)
    {
        this.RunAction(source, CCMoveToAction.GetSSAction(target, speed), this);
    }

    public void groupmoving(GameObject soure,Vector3[] target,float[] speed)
    {
        List<SSAction> aclist = new List<SSAction>();
        for(int i = 0; i < target.Length;i++)
        {
            aclist.Add(CCMoveToAction.GetSSAction(target[i], speed[i]));
        }
        CCSequenceAction moveseq = CCSequenceAction.GetSSAction(-1,1,aclist);
        this.RunAction(soure, moveseq, this);
    }

    public void SSActionEvent(SSAction source, SSActionEventType eventType = SSActionEventType.Competeted, int intParam = 0, string strParam = null, Object objParam = null)
    {
        if (source.gameobject.name.Equals("Boat"))
        {   //船完成动作  
            scene.boatReachBank();
        }
        else
        {   //人完成动作  
            scene.personFinishMoving();
        }
    }

    protected new void Update()
    {
        base.Update();
    }
}
