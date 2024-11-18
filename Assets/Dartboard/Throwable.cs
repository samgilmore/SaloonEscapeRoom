using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Rigidbody rb;
    OVRGrabbable grabbable;
    bool targetHit = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<OVRGrabbable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Board"))
        {
            Debug.Log("colided");

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

            Destroy(grabbable);

            // Check if velocity of dart is high enough to stick (test magnitude value)
            /*if(collision.relativeVelocity.magnitude > 1)
            {
                rb.isKinematic = true;
                transform.SetParent(collision.transform);
            }*/
        }
    }
}