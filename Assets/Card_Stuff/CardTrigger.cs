using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardTag
{
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

public class CardTrigger : MonoBehaviour
{
    public CardTag cardCollider = new();
    
    bool solved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(cardCollider.ToString()))
        {
            Debug.Log("touch");
            solved = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(cardCollider.ToString()))
        {
            Debug.Log("left");
            solved = false;
        }
    }

    public bool IsSolved  { get { return solved; } }
}
