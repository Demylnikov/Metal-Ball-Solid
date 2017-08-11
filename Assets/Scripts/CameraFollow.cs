using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Vector3 offset = new Vector3(3, 3, 0);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }

        if (player == null)
        {
            //Application.LoadLevel(Application.loadedLevelName);
            //Time.timeScale = 1;
            //Invoke("restart", 0.001f);
        }

    }

    void restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
        Time.timeScale = 1;
    }
}
