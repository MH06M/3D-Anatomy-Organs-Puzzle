using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;
    private float zCoordinate;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        // Save the object's current z position in screen space
        zCoordinate = mainCamera.WorldToScreenPoint(transform.position).z;

        // Calculate the offset between mouse position and object position
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        // Move the object to the mouse position with the offset
        transform.position = GetMouseWorldPosition() + offset;
    }

    Vector3 GetMouseWorldPosition()
    {
        // Convert mouse position to world space with the same z-coordinate as the object
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoordinate;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}