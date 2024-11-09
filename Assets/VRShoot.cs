using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    [Header("References")]
    public GameObject objectToShoot;
    public GameObject attackPoint;
    public ParticleSystem muzzleFlash;

    [Header("Settings")]
    public float shotCooldown;

    [Header("Shooting")]
    public float shootSpeed;

    bool readyToShoot;
    OVRGrabbable grabbable;
    AudioSource gunshotSound;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
        grabbable = GetComponent<OVRGrabbable>();
        gunshotSound = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

        if (grabbable.isGrabbed && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, grabbable.grabbedBy.GetController()) && readyToShoot)
        {
            Shoot();
        }
    }

    // ---------- //
    // ANIMATIONS //
    // ---------- //

    public const string HAMMER = "GunHammer";
    public const string RESET_HAMMER = "ResetHammer";

    private void Shoot()
    {
        gunshotSound.Play();
        muzzleFlash.Play();
        animator.Play(HAMMER);

        readyToShoot = false;

        // create arrow
        GameObject projectile = Instantiate(objectToShoot, attackPoint.transform.position, transform.rotation);

        // get the rigidbody of the arrow
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // add force
        Vector3 forceToAdd = transform.forward * shootSpeed;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        // shot cooldown
        Invoke(nameof(ResetShot), shotCooldown);
        Invoke(nameof(ResetHammer), 0.55f);
    }

    private void ResetHammer()
    {
        animator.Play(RESET_HAMMER);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
}
