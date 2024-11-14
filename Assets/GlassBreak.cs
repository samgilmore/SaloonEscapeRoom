using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class GlassBreak : MonoBehaviour
{
    [SerializeField] GameObject bottle;
    [SerializeField] GameObject brokenBottle;

    CapsuleCollider cc;

    private void Awake()
    {
        bottle.SetActive(true);           // Corrected SetActive
        brokenBottle.SetActive(false);

        cc = GetComponent<CapsuleCollider>(); // Corrected GetComponent
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            bottle.SetActive(false);
            brokenBottle.SetActive(true);

            cc.enabled = false;
        }
    }
}

