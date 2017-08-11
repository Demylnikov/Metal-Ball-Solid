using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb1 : MonoBehaviour {

    public GameObject bomb;
    public float posX = 115;
    public float posY = 14;
    public float posZ = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	
	void Update () {
	    	
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Instantiate(bomb, new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
}
