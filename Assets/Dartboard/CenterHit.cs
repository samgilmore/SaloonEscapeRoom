using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterHit : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int puzzleIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dart"))
        {
            if (!gameManager.puzzleCompleted[puzzleIndex])
            {
                gameManager.CompletePuzzle(puzzleIndex);
            }
        }
    }
}
