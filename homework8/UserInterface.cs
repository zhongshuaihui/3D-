using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Texture2D blood;   //血条  
    float Life = 100;            //总的生命值；  

    public Transform m_Transform;  //绑定血条的物体Transform组件；  

    void OnGUI()
    {
        Vector3 headPos = Camera.main.WorldToScreenPoint(m_Transform.position + Vector3.up * 2.5f);   //将该物体头上的一点转化为屏幕坐标；  
        GUI.DrawTexture(new Rect(headPos.x - 50, Screen.height - headPos.y, 100 * Life / Life, 3), blood);
    }
}
