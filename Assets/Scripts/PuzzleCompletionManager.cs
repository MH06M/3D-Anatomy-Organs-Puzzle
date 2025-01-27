using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

// Attach this script to an empty GameObject named "PuzzleManager" in your scene
public class PuzzleCompletionManager : MonoBehaviour
{
    // List of all SnapToGuide components in the scene
    private List<SnapToGuide> puzzlePieces = new List<SnapToGuide>();
    
    [SerializeField] private GameObject winPanel; // UI panel to show when player wins
    public UnityEvent onPuzzleComplete;
    private bool puzzleCompleted = false;

    void Start()
    {
        // Find all puzzle pieces with SnapToGuide component
        puzzlePieces.AddRange(FindObjectsOfType<SnapToGuide>());
        
        // Ensure win panel is hidden at start
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void Update()
    {
        if (!puzzleCompleted)
        {
            CheckPuzzleCompletion();
        }
    }

    void CheckPuzzleCompletion()
    {
        // Check if all pieces are snapped
        bool allPiecesSnapped = true;
        
        foreach (SnapToGuide piece in puzzlePieces)
        {
            if (!piece.IsSnapped())
            {
                allPiecesSnapped = false;
                break;
            }
        }

        if (allPiecesSnapped && !puzzleCompleted)
        {
            PuzzleComplete();
        }
    }

    void PuzzleComplete()
    {
        puzzleCompleted = true;
        

        // Show win panel
        if (winPanel != null)
            winPanel.SetActive(true);
            
        // Trigger win event
        onPuzzleComplete.Invoke();
        
        Debug.Log("Puzzle Completed! All pieces are in place!");
    }
}