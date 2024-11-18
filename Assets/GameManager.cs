using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Puzzle Status")]
    public bool[] puzzleCompleted = new bool[4];

    [Header("Exit Lights")]
    public GameObject[] lights;
    public Material redMaterial;
    public Material greenMaterial;

    [Header("Exit Door and Success Trigger")]
    public GameObject exitDoor;
    public GameObject successTrigger;

    void Start()
    {
        // Initialize all lights to red
        for (int i = 0; i < lights.Length; i++)
        {
            SetLightColor(i, redMaterial);
        }

        // Hide the success trigger initially
        if (successTrigger != null)
        {
            successTrigger.SetActive(false);
        }
    }

    public void CompletePuzzle(int puzzleIndex)
    {
        if (puzzleIndex < 0 || puzzleIndex >= puzzleCompleted.Length) return;
        if (puzzleCompleted[puzzleIndex]) return;

        puzzleCompleted[puzzleIndex] = true;

        SetLightColor(puzzleIndex, greenMaterial);

        if (AllPuzzlesSolved())
        {
            Debug.Log("All puzzles solved! You can escape now.");

            if (successTrigger != null)
            {
                successTrigger.SetActive(true);
            }

            if (exitDoor != null)
            {
                Invoke(nameof(HideExitDoor), 1.0f); // Delay to allow sounds to finish
            }
        }
    }

    private void HideExitDoor()
    {
        exitDoor.SetActive(false);
        Debug.Log("Exit door hidden.");
    }

    private void SetLightColor(int index, Material material)
    {
        if (index < 0 || index >= lights.Length) return;
        Renderer lightRenderer = lights[index].GetComponent<Renderer>();
        if (lightRenderer != null)
        {
            lightRenderer.material = material;
        }

        AudioSource audioSource = lights[index].GetComponent<AudioSource>();
        if (audioSource != null && material == greenMaterial)
        {
            audioSource.Play();
        }
    }

    private bool AllPuzzlesSolved()
    {
        foreach (bool solved in puzzleCompleted)
        {
            if (!solved) return false;
        }
        return true;
    }
}