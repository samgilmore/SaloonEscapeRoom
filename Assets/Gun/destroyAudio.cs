using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAudio : MonoBehaviour
{
    public void Die()
    {
        Invoke(nameof(DeathV2), 1);
    }

    public void DeathV2()
    {
        Destroy(gameObject);
    }
}
