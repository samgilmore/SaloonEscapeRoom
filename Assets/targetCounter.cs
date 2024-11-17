using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCounter : MonoBehaviour
{
    bool destroyed = false;

    public void SetDestroyed(bool destroyed) { this.destroyed = destroyed; }

    public bool GetDestroyed() { return destroyed; }
}
