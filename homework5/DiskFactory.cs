using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour {

    private int disknum = 0;
    private List<Disk> used = new List<Disk>();
    private List<Disk> free = new List<Disk>();

    public Disk getdisk(int lever)
    {
        Disk thedisk = null;
        if(free.Count > 0)
        {
            thedisk = free[0];
            thedisk.reset();
            used.Add(free[0]);
            free.Remove(free[0]);
        }
        else
        {
            disknum++;
            thedisk = new Disk(disknum);
            used.Add(thedisk);
        }
        return thedisk;
    }

    public void reset()
    {
        foreach(Disk temp in used)
        {
            temp.disk.SetActive(false);
            free.Add(temp);
        }
        used.Clear();
    }

    public int getuseddisknum()
    {
        return used.Count;
    }

    public void freedisk(Disk disk)
    {
        if(used.Contains(disk))
        {
            disk.score = Random.Range(1, 4);
            if (disk.score == 1)
                disk.setcolor(1);
            else if (disk.score == 2)
                disk.setcolor(2);
            else
                disk.setcolor(3);
            disk.disk.SetActive(false);
            used.Remove(disk);
            free.Add(disk);
        }
    }

    public Disk gethit(GameObject disk)
    {
        foreach(Disk i in used)
        {
            if (i.disk == disk)
                return i;
        }
        return null;
    }
}
