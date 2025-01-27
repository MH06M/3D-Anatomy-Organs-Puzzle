using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Transform orient;
    private GameObject selectedObject = null;
    private Vector3 rotationOffsetX = new Vector3(180, 0, 0); // Defined once as a class field
    private Vector3 rotationOffsetY = new Vector3(0, 180, 0); // Defined once as a class field
    private Vector3 rotationOffsetZ = new Vector3(0, 0, 180); // Defined once as a class field

    void Update()
    {
        // Check for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // Store the selected object
                selectedObject = hit.transform.gameObject;
                Debug.Log($"Selected object: {selectedObject.name}"); // Debug log to verify selection
            }
        }

        // Check for the interaction key press
        if (Input.GetKeyDown(KeyCode.X) && selectedObject != null)
        {
            // Get current rotation
            Vector3 currentRotation = selectedObject.transform.eulerAngles;
            // Apply the rotation offset
            selectedObject.transform.eulerAngles = currentRotation + rotationOffsetX;
            Debug.Log($"Rotated {selectedObject.name}"); // Debug log to verify rotation
        }
        if (Input.GetKeyDown(KeyCode.Y) && selectedObject != null)
        {
            // Get current rotation
            Vector3 currentRotation = selectedObject.transform.eulerAngles;
            // Apply the rotation offset
            selectedObject.transform.eulerAngles = currentRotation + rotationOffsetY;
            Debug.Log($"Rotated {selectedObject.name}"); // Debug log to verify rotation
        }
        if (Input.GetKeyDown(KeyCode.Z) && selectedObject != null)
        {
            // Get current rotation
            Vector3 currentRotation = selectedObject.transform.eulerAngles;
            // Apply the rotation offset
            selectedObject.transform.eulerAngles = currentRotation + rotationOffsetZ;
            Debug.Log($"Rotated {selectedObject.name}"); // Debug log to verify rotation
        }
    }
}