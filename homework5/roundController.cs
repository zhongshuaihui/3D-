using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;

public class roundController : MonoBehaviour, sceneController, UserAction
{

    public string status = "running";
    DiskFactory diskfactory;
    public int roundlever = 1;
    float time = 0;
    float senddisktime = 1;
    int numofsenddisk = 1;

    CCActionManager actionManager;
    public ScoreController scorecontroll = new ScoreController();

    private void Awake()
    {
        Director director = Director.getInstance();
        director.currentSceneController = this;
        this.gameObject.AddComponent<DiskFactory>();
        this.gameObject.AddComponent<CCActionManager>();
        this.gameObject.AddComponent<UserGUI>();
    }

    // Use this for initialization
    void Start () {
        diskfactory = Singleton<DiskFactory>.Instance;
        actionManager = Singleton<CCActionManager>.Instance;
    }
	
	// Update is called once per frame
	void Update () {
		if(status == "running")
        {
            if(roundlever > 3)
            {
                if (diskfactory.getuseddisknum() == 0)
                    status = "gameover";
                return;
            }
            if(numofsenddisk >= 10)
            {
                numofsenddisk = 0;
                roundlever++;
            }
            time += Time.deltaTime;
            checkifsend();
        }
	}

    public void hitDisk(GameObject disk)
    {
        Disk temp = diskfactory.gethit(disk);
        if (temp == null)
        {
            Debug.Log("the disk of clicked is null? ");
        }
        else
        {
            scorecontroll.addScore(temp.score);
            diskfactory.freedisk(temp);
        }
    }

    private void checkifsend()
    {
        if (time > senddisktime)
        {
            senddisk(roundlever);
            time = 0;
        }
    }

    private void senddisk(int sendLever)
    {
        numofsenddisk++;
        Disk oneDisk = diskfactory.getdisk(sendLever);
        diskmove moveAction = diskmove.getdiskmove(oneDisk, sendLever);
        actionManager.Run(oneDisk.disk, moveAction, null);
    }

    public void reset()
    {
        actionManager.reset();
        diskfactory.reset();
        scorecontroll.reset();
        roundlever = 1;
        numofsenddisk = 0;
        status = "running";
    }

    public void loadResources()
    {
    }
}

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }
}
