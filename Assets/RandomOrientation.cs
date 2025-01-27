using UnityEngine;

public class RandomOrientation : MonoBehaviour
{
    [Range(1, 10)]
    public int maxRotationsX = 4;
    [Range(1, 10)]
    public int maxRotationsY = 4;
    [Range(1, 10)]
    public int maxRotationsZ = 4;

    void Start()
    {
        // Get current rotation
        Vector3 currentRotation = transform.eulerAngles;

        // Generate random integers for each axis
        int randomX = Random.Range(0, maxRotationsX);
        int randomY = Random.Range(0, maxRotationsY);
        int randomZ = Random.Range(0, maxRotationsZ);

        // Calculate new rotation
        Vector3 newRotation = new Vector3(
            currentRotation.x + (180 * randomX),
            currentRotation.y + (180 * randomY),
            currentRotation.z + (180 * randomZ)
        );

        // Apply the new rotation
        transform.eulerAngles = newRotation;

        // Debug log to verify the rotation
        Debug.Log($"Original Rotation: {currentRotation}");
        Debug.Log($"Random Multipliers: X={randomX}, Y={randomY}, Z={randomZ}");
        Debug.Log($"New Rotation: {newRotation}");
    }
}