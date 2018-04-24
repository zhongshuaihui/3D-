using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk
{
    public GameObject disk;
    public int diskid;
    public int lever;
    public int score;

    public Disk(int id)
    {
        this.diskid = id;
        int i;
        i = UnityEngine.Random.Range(1, 4);
        if (i == 1)
        {
            disk = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Ufo"), Vector3.zero, Quaternion.identity);
            this.score = 1;
            disk.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if(i == 2)
        {
            disk = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Ufo"), Vector3.zero, Quaternion.identity);
            this.score = 2;
            disk.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else
        {
            disk = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Ufo"), Vector3.zero, Quaternion.identity);
            this.score = 3;
            disk.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        disk.name = "disk" + id.ToString();
        reset();
    }

    public void setcolor(int i)
    {
        if(i == 1)
            disk.GetComponent<MeshRenderer>().material.color = Color.green;
        else if(i == 2)
            disk.GetComponent<MeshRenderer>().material.color = Color.yellow;
        else
            disk.GetComponent<MeshRenderer>().material.color = Color.red;
        reset();
    }

    public void reset()
    {
        disk.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(0f, 2f));
        if (score == 1)
            disk.transform.localScale = new Vector3(3, 0.3f, 3);
        else if (score == 2)
            disk.transform.localScale = new Vector3(2, 0.2f, 2);
        else
            disk.transform.localScale = new Vector3(1, 0.1f, 1);
        disk.SetActive(true);
    }
}

public enum SSActionEventType : int { start, complete }

public interface ISSActionCallback
{
    void SSActionEvent(SSActionEventType source, SSActionEventType events = SSActionEventType.complete, int intParam = 0, string strParam = null, Object objectParam = null);
}

public class SSAction : ScriptableObject
{
    public bool enable = true;
    public bool destroy = false;
    public GameObject gameobject { get; set; }
    public Transform transform { get; set; }
    public ISSActionCallback callback { get; set; }
    protected SSAction() { }
    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }
    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}

public class diskmove : SSAction
{
    public Vector3 des;
    public float speed;
    public Disk thedisk;
    public float time = 0;

    public override void Start()
    {

    }

    public static diskmove getdiskmove(Disk disk, int lever)
    {
        diskmove action = ScriptableObject.CreateInstance<diskmove>();
        if (lever == 1)
            action.speed = 6f;
        else if (lever == 2)
            action.speed = 8f;
        else
            action.speed = 10f;
        action.thedisk = disk;
        action.des = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 20f);
        return action;
    }

    public override void Update()
    {
        gameobject.transform.position = Vector3.MoveTowards(gameobject.transform.position, des, speed * Time.deltaTime);
        if (this.transform.position == des)
        {
            this.destroy = true;
            this.enable = false;
            Singleton<DiskFactory>.Instance.freedisk(thedisk);
            thedisk.disk.SetActive(false);
        }
    }
}

public class CCActionManager : SSActionManager, ISSActionCallback
{

    public void reset()
    {
        action.Clear();
    }

    public void SSActionEvent(SSActionEventType source, SSActionEventType events = SSActionEventType.complete, int intParam = 0, string strParam = null, Object objectParam = null)
    {

    }
}

public class ScoreController
{
    int score = 0;

    public void addScore(int _score)
    {
        score += _score;
    }

    public int getscore()
    {
        return score;
    }

    public void reset()
    {
        score = 0;
    }
}