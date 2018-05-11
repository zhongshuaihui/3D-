using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Patrols;

public class UserInterface : MonoBehaviour
{
    private IUserAction action;

    void Start()
    {
        action = SceneController.getInstance() as IUserAction;
    }

    void Update()
    {
        detectKeyInput();
    }

    void detectKeyInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            action.heromove(Diretion.UP);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            action.heromove(Diretion.DOWN);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            action.heromove(Diretion.LEFT);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            action.heromove(Diretion.RIGHT);
        }
    }
}