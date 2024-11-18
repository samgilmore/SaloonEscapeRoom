using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(destroyPieces), 3f);
    }

    private void destroyPieces()
    {
        Destroy(gameObject);
    }
}
