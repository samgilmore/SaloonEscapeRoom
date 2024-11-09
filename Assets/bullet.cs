using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    AudioSource hit;
    destroyAudio destroyAudio;

    private void Start()
    {
        hit = GetComponentInChildren<AudioSource>();
        destroyAudio = GetComponentInChildren<destroyAudio>();
    }

    private void OnCollisionEnter(Collision objectWeHit)
    {
        if (objectWeHit.gameObject.CompareTag("Wood"))
        {
            CreateBulletImpactEffect(objectWeHit);

            GameObject audio = hit.gameObject;
            audio.transform.SetParent(null);
            hit.Play();
            destroyAudio.Die();

            Destroy(gameObject);
        }
    }

    private void CreateBulletImpactEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject hole = Instantiate(GlobalReferences.Instance.bulletImpactEffectPrefab, contact.point, Quaternion.LookRotation(contact.normal));

        hole.transform.SetParent(objectWeHit.gameObject.transform);
    }
}
