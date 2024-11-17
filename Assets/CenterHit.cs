using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterHit : MonoBehaviour
{
    public GameObject targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            if (other.transform.position == targetPoint.transform.position)
            { 
                // Dart hits center of board
            }
        }
    }
}
