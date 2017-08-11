using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter : MonoBehaviour {

    public float maxSpeed = 1000;
    public Rigidbody rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update () {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
