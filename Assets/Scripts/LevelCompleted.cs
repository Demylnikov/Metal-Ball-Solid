using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour {

    public GameObject levelCompletedText;
    public GameObject player;

	// Use this for initialization
	void Start () {
        levelCompletedText.transform.localScale = new Vector3(0, 0, 0);
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Invoke("restart", 0.2f);
            Debug.Log("player is null");
        }
        Debug.Log("This is getting called in LevelCompleted");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelCompletedText.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
        Time.timeScale = 1;
    }

}
