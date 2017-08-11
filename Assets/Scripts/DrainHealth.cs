using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainHealth : MonoBehaviour {

    public GameObject player;
    public float damage = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("tried to call OnTriggerStay");
            player.GetComponent<PlayerMovement>().reduceHp(damage);
        }
    }

}
