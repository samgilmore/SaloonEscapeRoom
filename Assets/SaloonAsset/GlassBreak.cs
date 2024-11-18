using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class GlassBreak : MonoBehaviour
{
    [SerializeField] GameObject bottle;
    [SerializeField] GameObject brokenBottle;

    BoxCollider cc;
    public AudioSource audioSource; 

    private void Awake()
    {
        bottle.SetActive(true);
        brokenBottle.SetActive(false);

        cc = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            bottle.SetActive(false);
            brokenBottle.SetActive(true);

            cc.enabled = false;

            // Play the glass break sound
            if (audioSource != null)
            {
                audioSource.time = 0.2f;
                audioSource.Play();
            }
        }
    }

    public bool IsBottleActive() { return bottle.activeSelf; }
}


