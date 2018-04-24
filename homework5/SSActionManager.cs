using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;

public class SSActionManager : MonoBehaviour {

    protected Dictionary<int, SSAction> action = new Dictionary<int, SSAction>();
    protected List<SSAction> addlist = new List<SSAction>();
    protected List<int> deletlist = new List<int>();
    protected roundController round;

    public SSActionManager()
    {
        round = (roundController)Director.getInstance().currentSceneController;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(round.status == "running")
        {
            foreach (SSAction ssaction in addlist)
                action[ssaction.GetInstanceID()] = ssaction;
            addlist.Clear();
            foreach(KeyValuePair<int,SSAction> keyvalue in action)
            {
                SSAction ssaction = keyvalue.Value;
                if (ssaction.gameobject.active == false || ssaction.destroy)
                    deletlist.Add(ssaction.GetInstanceID());
                else if (ssaction.enable)
                    ssaction.Update();
            }
            foreach(int key in deletlist)
            {
                SSAction ssaction = action[key];
                action.Remove(key);
                DestroyObject(ssaction);
            }
            deletlist.Clear();
        }
	}

    public void Run(GameObject gameobject,SSAction ssaction,ISSActionCallback iss)
    {
        ssaction.gameobject = gameobject;
        ssaction.transform = gameobject.transform;
        ssaction.callback = iss;
        addlist.Add(ssaction);
        ssaction.Start();
    }
}
