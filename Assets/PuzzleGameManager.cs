using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{
    public Transform[] puzzleParts; // Drag and drop parts to check their positions
    public Transform[] correctPositions; // Target positions for each part
    public float acceptableDistance = 0.1f; // Distance threshold for correct position
    public float acceptableAngle = 5f; // Angle threshold for correct rotation
    public float maxTime = 60f; // Time limit in seconds
    public Text timerText; // UI Text for displaying the timer
    public GameObject victoryMessage; // UI element for victory message
    public AudioClip victorySound; // Audio clip for victory sound

    private AudioSource audioSource;
    private float timeRemaining;
    private bool gameWon = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeRemaining = maxTime;
        victoryMessage.SetActive(false);
    }

    void Update()
    {
        if (!gameWon)
        {
            UpdateTimer();
            CheckVictoryCondition();
        }
    }

    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "Time's Up!";
        }
    }

    void CheckVictoryCondition()
    {
        bool allPartsCorrect = true;

        for (int i = 0; i < puzzleParts.Length; i++)
        {
            float distance = Vector3.Distance(puzzleParts[i].position, correctPositions[i].position);
            float angle = Quaternion.Angle(puzzleParts[i].rotation, correctPositions[i].rotation);

            if (distance > acceptableDistance || angle > acceptableAngle)
            {
                allPartsCorrect = false;
                break;
            }
        }

        if (allPartsCorrect && timeRemaining > 0)
        {
            TriggerVictory();
        }
    }

    void TriggerVictory()
    {
        gameWon = true;
        victoryMessage.SetActive(true);

        if (victorySound != null)
        {
            audioSource.PlayOneShot(victorySound);
        }
    }
}