using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptybehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(Vector3.zero, new Vector3(0, 1, 1), 60 * Time.deltaTime);

    }
}
