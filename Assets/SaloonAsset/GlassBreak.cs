using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class GlassBreak : MonoBehaviour
{
    [SerializeField] GameObject bottle;
    [SerializeField] GameObject brokenBottle;
    [SerializeField] AudioClip glassBreakSound; 

    CapsuleCollider cc;
    AudioSource audioSource; 

    private void Awake()
    {
        bottle.SetActive(true);
        brokenBottle.SetActive(false);

        cc = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            bottle.SetActive(false);
            brokenBottle.SetActive(true);

            cc.enabled = false;

            // Play the glass break sound
            if (glassBreakSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(glassBreakSound);
            }
        }
    }
}


