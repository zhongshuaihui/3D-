# 血条显示


----------

本次作业的要求有两个，分别使用 IMGUI 和 UGUI 实现血条的显示，观看[展示视频](https://pan.baidu.com/s/123tCfiMhwbtrDmgYuyvnjA)请点此处。
1. IMGUI实现
[参考博客](https://blog.csdn.net/CJB_King/article/details/52091159)
IMGUI主要就是利用GUI，创建一个位置一直为目标头顶的血条，其实现代码如下

``` c#
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

```
将UserInterface挂载到maincamera上，blood可为红色的png图片<br>
![血条.png](https://github.com/zhongshuaihui/3D-game-learning/blob/master/homework8/%E8%A1%80%E6%9D%A1.PNG)

2. UGUI实现
参考教程为老师提供的网站上的方法
![UGUI.JPG](https://github.com/zhongshuaihui/3D-game-learning/blob/master/homework8/UGUI.JPG)<br>
根据教程，制作出来的血条是会随着人物的转向而转向的，所以就要用以下代码使得其不会转向

  ``` javascript
  using UnityEngine;

  public class LookAtCamera : MonoBehaviour
  {

      void Update()
      {
          this.transform.LookAt(Camera.main.transform.position);
      }
  }
  ```
