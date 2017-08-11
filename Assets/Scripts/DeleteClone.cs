using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteClone : MonoBehaviour {

    public GameObject explosion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        explosion = GameObject.FindGameObjectWithTag("ExplosionEffect");
        Destroy(explosion, 0.3f);
    }
}
