using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private Collider[] hitColliders;
    public float blastRadius = 10;
    public float explosionPower = 2000;
    public LayerMask explosionLayers;
    public ParticleSystem explosionEffect;
    public Transform bomb;
    public GameObject bombObject;
    public GameObject explosion;
    public GameObject playerObject;
    public int damageToPlayer = 20;

    public PlayerMovement playerController;

    void Update()
    {
        bombObject = GameObject.FindGameObjectWithTag("Bomb");
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void ExplosionWork(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

        foreach (Collider hitCol in hitColliders)
        {
            Debug.Log("Hit this object " + hitCol.gameObject.name);
            if (hitCol.GetComponent<Rigidbody>() != null)
            {
                //hitCol.GetComponent<Rigidbody> ().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
                //Destroy(bombObject); the one below probably doesnt get called because it cant find explosion effect
                playerObject.GetComponent<PlayerMovement>().reduceHp((float)damageToPlayer);
                //playerController.reduceHp(damageToPlayer); //blocks everything below
                Destroy(this.gameObject);
                //Destroy(playerObject); this works
                
                Instantiate(explosionEffect, new Vector3(bomb.transform.position.x, bomb.transform.position.y, bomb.transform.position.y), Quaternion.identity);
                if (!explosionEffect.isPlaying)
                {
                    Debug.Log("effects stopped playing");
                    //explosionEffect.Play ();
                    explosion = GameObject.FindGameObjectWithTag("ExplosionEffect");
                    //Destroy (explosion);
                }
                //Destroy (bombObject);
                //Debug.Log("Tried to destroy the bomb");
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        ExplosionWork(col.contacts[0].point);
    }

}
