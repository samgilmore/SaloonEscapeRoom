using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public GameObject crackedTarget;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newTarget = Instantiate(crackedTarget, transform.position, transform.rotation);
        newTarget.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, 1);
        Destroy(gameObject);
    }
}
