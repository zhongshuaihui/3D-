using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private int[,] blocks = new int[3, 3];
    private int user = -1;
    private int lastrow;
    private int lastcol;

    // Use this for initialization
    void Start () {
        resetgame();
        lastrow = -1;
        lastcol = -1;
	}

    private void OnGUI()
    {
        if(user == -1)
            GUI.Label(new Rect(450, 50, 100, 50), "O方落子!");
        else
            GUI.Label(new Rect(450, 50, 100, 50), "X方落子!");
        if (GUI.Button(new Rect(550, 400, 100, 50), "Reset"))
            resetgame();
        if (GUI.Button(new Rect(350, 400, 100, 50), "悔棋"))
            returnlastgame();
        int win = judge(); 
        if(win == -1)
        {
            GUI.Label(new Rect(450, 300, 100, 50), "O方胜利!");
            GUI.Label(new Rect(400, 315, 150, 50), "请按reset重新开始游戏");
        }
        else if (win == 1)
        {
            GUI.Label(new Rect(450, 300, 100, 50), "X方胜利!");
            GUI.Label(new Rect(400, 315, 150, 50), "请按reset重新开始游戏");
        }
        else if (win == 2)
        {
            GUI.Label(new Rect(450, 300, 100, 50), "双方平局!");
            GUI.Label(new Rect(400, 315, 150, 50), "请按reset重新开始游戏");
        }
        for (int j = 0;j < 3; j++)
        {
            for (int k = 0;k < 3; k++)
            { 
                if (blocks[j, k] == 1)
                    GUI.Button(new Rect(400 + j * 50, 100 + k * 50, 50, 50), "X");
                if (blocks[j, k] == -1)
                    GUI.Button(new Rect(400 + j * 50, 100 + k * 50, 50, 50), "O");
                if(GUI.Button(new Rect(400 + j * 50, 100 + k * 50, 50, 50), ""))
                {
                    if(win == 0)
                    {
                        blocks[j, k] = user;
                        user = -user;
                        lastrow = j;
                        lastcol = k;
                    }
                }

            }
        }
    }

    void resetgame()
    {
        user = -1;
        for (int j = 0; j < 3; j++)
            for (int k = 0; k < 3; k++)
                blocks[j, k] = 0;
    }

    void returnlastgame()
    {
        if(lastrow != -1)
        {
            blocks[lastrow, lastcol] = 0;
            lastrow = -1;
            lastcol = -1;
            user = -user;
        }
    }

    int judge()
    {
        for(int i = 0;i < 3; i++)//判断横向
            if (blocks[i, 0] != 0 && blocks[i, 0] == blocks[i, 1] && blocks[i, 0] == blocks[i, 2])
                return blocks[i, 0];
        
        for (int i = 0;i < 3; i++)//判断纵向
            if (blocks[0, i] != 0 && blocks[0, i] == blocks[1, i] && blocks[0, i] == blocks[2, i])
                return blocks[0, i];

        if (
            blocks[1, 1] != 0 &&
            (blocks[0, 0] == blocks[1, 1] && blocks[0, 0] == blocks[2, 2] ||
            blocks[0, 2] == blocks[1, 1] && blocks[0, 2] == blocks[2, 0])
            )//判断斜线
            return blocks[1, 1];

        for (int j = 0; j < 3; j++)//有空格游戏继续
        {
            for (int k = 0; k < 3; k++)
            {
                if (blocks[j, k] == 0)
                    return 0;
            }      
        }
            
        
        return 2;
    }
}
