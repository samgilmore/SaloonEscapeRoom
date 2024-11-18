using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    [Header("References")]
    public GameObject objectToShoot;
    public GameObject attackPoint;
    public ParticleSystem muzzleFlash;
    public OVRGrabber leftGrabber;
    public OVRGrabber rightGrabber;

    [Header("Settings")]
    public float shotCooldown;

    [Header("Shooting")]
    public float shootSpeed;

    [Header("Haptics")]
    public float hapticStrength = 0.5f;
    public float hapticDuration = 0.2f;

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

        if (grabbable.isGrabbed && readyToShoot)
        {
            if (grabbable.grabbedBy == leftGrabber && triggerLeft > 0.5f)
            {
                Shoot(leftGrabber);
            }
            if (grabbable.grabbedBy == rightGrabber && triggerRight > 0.5f)
            {
                Shoot(rightGrabber);
            }
        }
    }

    // ---------- //
    // ANIMATIONS //
    // ---------- //

    public const string HAMMER = "GunHammer";
    public const string RESET_HAMMER = "ResetHammer";

    private void Shoot(OVRGrabber grabber)
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

        TriggerHaptics(grabber);

        // shot cooldown
        Invoke(nameof(ResetShot), shotCooldown);
        Invoke(nameof(ResetHammer), 0.55f);

        // destroy bullet after a few seconds
        StartCoroutine(DestroyBullet(projectile));
    }

    private void ResetHammer()
    {
        animator.Play(RESET_HAMMER);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private IEnumerator DestroyBullet(GameObject projectile)
    {
        yield return new WaitForSeconds(5);
        Destroy(projectile);
    }

    private void TriggerHaptics(OVRGrabber grabber)
    {
        if (grabber == leftGrabber)
        {
            OVRInput.SetControllerVibration(hapticStrength, hapticStrength, OVRInput.Controller.LTouch);
        }
        else if (grabber == rightGrabber)
        {
            OVRInput.SetControllerVibration(hapticStrength, hapticStrength, OVRInput.Controller.RTouch);
        }

        Invoke(nameof(StopHaptics), hapticDuration);
    }

    private void StopHaptics()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> temp
