using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    public GameObject destroyedCrate;
    public float delay = 5f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;
    public bool isTimed = false;
    public bool isControlled = false;

    float countdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }//if
    }

    void Explode()
    {
        //Debug.Log("BOOM!");

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders1 = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nerbyObject in colliders1)
        {
            GameObject gm = nerbyObject.gameObject;

           
                if(gm.tag == "Crate")
            {
                Transform transformC = gm.transform;
                Destroy(gm);

                Instantiate(destroyedCrate, transformC.position, transformC.rotation);

            }
            

        }//foreach

        Collider[] colliders2 = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nerbyObject in colliders2)
        {
            Rigidbody rb = nerbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }

            if (nerbyObject.gameObject.tag == "Destroyed Crate")
            {
                Destroy(nerbyObject.gameObject, 15f);
            }
        }//foreach

        Destroy(gameObject);
    }//Explode
}
