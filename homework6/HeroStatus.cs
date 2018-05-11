using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Patrols;

// 加在hero上

public class HeroStatus : MonoBehaviour
{
    public int standOnArea = -1;

    void Update()
    {
        modifyStandOnArea();
    }

    //检测所在区域
    void modifyStandOnArea()
    {
        float posX = this.gameObject.transform.position.x;
        float posZ = this.gameObject.transform.position.z;
        if (posZ >= 0)
        {
            if (posX < 0)
                standOnArea = 0;
            else if (posX > 0)
                standOnArea = 1;
        }
        else
        {
            if (posX < 0)
                standOnArea = 2;
            else if (posX > 0)
                standOnArea = 3;
        }
    }
}