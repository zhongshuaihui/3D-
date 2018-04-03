﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunbehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Mercury").transform.RotateAround(Vector3.zero, new Vector3(0, 0, 1), 80 * Time.deltaTime);
        GameObject.Find("Mercury").transform.Rotate(Vector3.up * Time.deltaTime * 10000);
        GameObject.Find("Venus").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 70 * Time.deltaTime);
        GameObject.Find("Venus").transform.Rotate(Vector3.up * Time.deltaTime * 10000);
        GameObject.Find("Earth").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 1), 60 * Time.deltaTime);
        GameObject.Find("Earth").transform.Rotate(Vector3.up * Time.deltaTime * 10000);
        GameObject.Find("Mars").transform.RotateAround(Vector3.zero, new Vector3(0, 2, 1), 50 * Time.deltaTime);
        GameObject.Find("Mars").transform.Rotate(Vector3.up * Time.deltaTime * 10000);
        GameObject.Find("Jupiter").transform.RotateAround(Vector3.zero, new Vector3(0, 0, 1), 40 * Time.deltaTime);
        GameObject.Find("Jupiter").transform.Rotate(Vector3.up * Time.deltaTime * 10000);
        GameObject.Find("Saturn").transform.RotateAround(Vector3.zero, new Vector3(1, 1, 0), 30 * Time.deltaTime);
        GameObject.Find("Saturn").transform.Rotate(Vector3.up * Time.deltaTime * 10000);
        GameObject.Find("Uranus").transform.RotateAround(Vector3.zero, new Vector3(1, 1, 1), 20 * Time.deltaTime);
        GameObject.Find("Uranus").transform.Rotate(Vector3.up * Time.deltaTime * 10000);
        GameObject.Find("Neptune").transform.RotateAround(Vector3.zero, new Vector3(1, 0, 2), 10 * Time.deltaTime);
        GameObject.Find("Neptune").transform.Rotate(Vector3.up * Time.deltaTime * 10000);

    }
}