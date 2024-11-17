using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allTargets : MonoBehaviour
{
    List<TargetCounter> childrenCounters;
    bool solved = false;

    // Start is called before the first frame update
    void Start()
    {
        childrenCounters = new List<TargetCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        bool yep = true;
        if (childrenCounters.Count == 0) { yep = false; }
        if (transform.childCount != childrenCounters.Count) { return; }
        for (int i = 0; i < childrenCounters.Count; i++)
        {
            if (!childrenCounters[i].GetDestroyed())
            {
                yep = false;
            }
        }
        solved = yep;
        if ( solved ) { solvedd(); }
    }

    public List<TargetCounter> GetTargetCounters() { return childrenCounters; }

    void solvedd()
    {
        Debug.Log("done");
    }
}
