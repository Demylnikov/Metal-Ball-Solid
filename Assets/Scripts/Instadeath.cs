using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instadeath : MonoBehaviour {

    public GameObject player;
    public float damage = 105;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("tried to call OnTriggerStay");
            player.GetComponent<PlayerMovement>().reduceHp(damage);
        }
    }

}
