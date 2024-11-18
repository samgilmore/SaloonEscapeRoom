using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allTargets : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int puzzleIndex;

    List<TargetCounter> childrenCounters;

    void Start()
    {
        childrenCounters = new List<TargetCounter>(GetComponentsInChildren<TargetCounter>());
    }

    void Update()
    {
        if (childrenCounters.Count == 0) { return; }

        bool solved = true;

        foreach (var targetCounter in childrenCounters)
        {
            if (!targetCounter.GetDestroyed())
            {
                solved = false;
                break;
            }
        }

        if (!gameManager.puzzleCompleted[puzzleIndex] && solved)
        {
            Debug.Log("All targets destroyed");
            gameManager.CompletePuzzle(puzzleIndex);
        }
    }

    public List<TargetCounter> GetTargetCounters() { return childrenCounters; }
}
