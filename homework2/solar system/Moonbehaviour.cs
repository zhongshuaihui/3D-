using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonbehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = this.transform.parent.position;
        this.transform.RotateAround(position, Vector3.up, 200 * Time.deltaTime);
	}
}
