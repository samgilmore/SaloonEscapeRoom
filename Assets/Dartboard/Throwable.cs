using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Rigidbody rb;
    bool targetHit = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit)
        {
            return;
        }
        else
        {
            targetHit = true;
        }

        rb.isKinematic = true; // makes projectile stick to surface

        transform.SetParent(collision.transform);

        // Check if velocity of dart is high enough to stick (test magnitude value)
        /*if(collision.relativeVelocity.magnitude > 1)
        {
            rb.isKinematic = true;
            transform.SetParent(collision.transform);
        }*/
    }
}
