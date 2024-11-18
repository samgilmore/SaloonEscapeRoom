using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSolved : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int puzzleIndex;

    List<CardTrigger> childrenTriggers;

    // Start is called before the first frame update
    void Start()
    {
        childrenTriggers = new List<CardTrigger>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            childrenTriggers.Add(gameObject.transform.GetChild(i).GetComponent<CardTrigger>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool solved = true;
        for (int i = 0; i < childrenTriggers.Count; i++)
        {
            if (!childrenTriggers[i].IsSolved)
            {
                solved = false;
                break;
            }
        }

        if (solved && !gameManager.puzzleCompleted[puzzleIndex])
        {
            Debug.Log("Cards placed correctly!");
            gameManager.CompletePuzzle(puzzleIndex);
        }
    }
}
