using UnityEngine;

public class SnapToGuide : MonoBehaviour
{
    [Header("Guide Settings")]
    public Transform guideObject;
    public float snapThreshold = 0.5f;
    public float rotationThreshold = 5f;

    [Header("Material Settings")]
    public Material defaultMaterial;
    public Material highlightMaterial;

    [Header("Sound Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip snapSound;

    private bool isSnapped = false;
    private Renderer pieceRenderer;
    private Color originalColor;
    private bool isHovered = false;

    void Start()
    {
        pieceRenderer = GetComponent<Renderer>();
        originalColor = pieceRenderer.material.color;

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f;
            audioSource.volume = 1f;
        }
    }

    void Update()
    {
        if (!isSnapped)
        {
            float distance = Vector3.Distance(transform.position, guideObject.position);
            float angle = Quaternion.Angle(transform.rotation, guideObject.rotation);

            if (distance < snapThreshold && angle < rotationThreshold)
            {
                if (!isHovered)
                {
                    HighlightPiece(true);
                    isHovered = true;
                }
            }
            else
            {
                if (isHovered)
                {
                    HighlightPiece(false);
                    isHovered = false;
                }
            }

            // Only snap and play sound when mouse is released while in correct position
            if (Input.GetMouseButtonUp(0) && isHovered)
            {
                SnapPiece();
                PlaySnapSound(); // Play sound only after successful snap
            }
        }
    }

    void HighlightPiece(bool isHighlighted)
    {
        pieceRenderer.material = isHighlighted ? highlightMaterial : defaultMaterial;
    }

    void SnapPiece()
    {
        transform.position = guideObject.position;
        transform.rotation = guideObject.rotation;
        isSnapped = true;
        Debug.Log("Piece snapped into place!");
    }

    void PlaySnapSound()
    {
        if (snapSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(snapSound);
        }
    }

    public bool IsSnapped()
    {
        return isSnapped;
    }
}