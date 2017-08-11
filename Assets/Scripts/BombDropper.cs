using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour {

    public GameObject bomb;
    public float rateOfDrop = 0.5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("dropBomb", 3, rateOfDrop);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void dropBomb()
    {

        float referencePointX = this.gameObject.transform.position.x;
        float referencePointY = this.gameObject.transform.position.y;
        float referencePointZ = this.gameObject.transform.position.z;

        float scaleX = this.gameObject.transform.localScale.x;

        float randomX = Random.Range(referencePointX-scaleX/2, referencePointX+scaleX/2);

        Instantiate(bomb, new Vector3(randomX, referencePointY, referencePointZ), Quaternion.identity);
    }

}
