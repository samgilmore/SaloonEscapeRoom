using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSolved : MonoBehaviour
{
    List<CardTrigger> childrenTriggers;
    bool solved = false;

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
        bool yep = true;
        for (int i = 0; i < childrenTriggers.Count; i++)
        {
            if (!childrenTriggers[i].IsSolved)
            {
                yep = false;
            }
        }
        solved = yep;
        if (solved) { solveddd(); }
    }

    void solveddd()
    {
        Debug.Log("done");
    }
}
