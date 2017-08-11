using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public int rotationSpeed = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
	}
}
