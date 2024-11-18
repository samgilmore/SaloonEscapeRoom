using UnityEngine;

public class BottlePuzzleTracker : MonoBehaviour
{
    [Header("Bottle Objects")]
    [SerializeField] private GlassBreak[] bottles;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int puzzleIndex;

    private void Update()
    {
        bool allBroken = true;
        foreach (var bottle in bottles)
        {
            if (bottle != null && bottle.gameObject.activeSelf)
            {
                allBroken = false;
                break;
            }
        }

        if (allBroken && !gameManager.puzzleCompleted[puzzleIndex])
        {
            Debug.Log("All bottles broken! Puzzle completed.");
            gameManager.CompletePuzzle(puzzleIndex);
        }
    }
}