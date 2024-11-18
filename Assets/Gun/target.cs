using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public GameObject crackedTarget;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        List<TargetCounter> counters = parent.GetComponent<allTargets>().GetTargetCounters();

        TargetCounter counter = GetComponentInChildren<TargetCounter>();
        counter.SetDestroyed(true);
        counters.Add(counter);

        GameObject newTarget = Instantiate(crackedTarget, transform.position, transform.rotation);
        newTarget.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, 0.5f);


        counter.transform.SetParent(newTarget.transform);
        newTarget.transform.SetParent(parent.transform);

        Destroy(gameObject);
    }
}
