using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float ballVelocity = 2000;
    public float jumpVelocity = 500;
    public float dashVelocity = 3000;
    public float distanceToGround;
    public Rigidbody rb;
    public float hp;
    public GameObject healthBar;
    public GameObject wastedText;
    bool playerDied;

    private void Start()
    {
        hp = 100;
        wastedText.transform.localScale = new Vector3(0, 0, 0);
    }

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    public void reduceHp(float damage)
    {
        Debug.Log("reduceHP was called");
        hp = hp - damage;
        setHealtBar(hp);
    }

    public void setHealtBar(float health)
    {
        if (health < 0)
        {
            healthBar.transform.localScale = new Vector3(0, 1, 1);
        }
        else
        {
            healthBar.transform.localScale = new Vector3((float)health / 100, 1, 1);
        }
    }

    

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("right") && isGrounded())
        {
            rb.AddForce(new Vector3(ballVelocity, 0, 0));
        }

        if (Input.GetKeyDown("left") && isGrounded())
        {
            rb.AddForce(new Vector3(-ballVelocity, 0, 0));
        }

        if (Input.GetKeyDown("space") && isGrounded())
        {
            rb.AddForce(new Vector3(0, jumpVelocity, 0));
        }

        if (Input.GetKeyDown("right") && Input.GetKeyDown("space") && isGrounded())
        {
            rb.AddForce(new Vector3(ballVelocity, jumpVelocity, 0));
        }

        if (Input.GetKeyDown("left") && Input.GetKeyDown("space") && isGrounded())
        {
            rb.AddForce(new Vector3(-ballVelocity, jumpVelocity, 0));
        }

        if (Input.GetKeyDown("right") && !isGrounded())
        {
            rb.AddForce(new Vector3(dashVelocity, 0, 0));
        }

        if (Input.GetKeyDown("left") && !isGrounded())
        {
            rb.AddForce(new Vector3(-dashVelocity, 0, 0));
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (hp == 0 || hp < 0)
        {
            Debug.Log("Player died");
            Destroy(this.gameObject);
            playerDied = true;
        }

        if (playerDied)
        {
            Time.timeScale = 0.05f;
            Debug.Log("Game slowed down");
            wastedText.transform.localScale = new Vector3(3, 3, 1);
            Invoke("test", 0.2f);
            Debug.Log("Invoke started");
            
        }

        if (Input.GetKeyDown("space") && playerDied)    //doesnt get called
        {
            Debug.Log("Attempted to restart level");
            Application.LoadLevel(Application.loadedLevelName);
            Time.timeScale = 1;
        }



        //Debug.Log("Grounded: " + isGrounded());
            Debug.Log("HP: " + hp);
    }

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevelName);
        Time.timeScale = 1;
    }

    public void test()
    {
        Debug.Log("Test invoked");
    }

}
