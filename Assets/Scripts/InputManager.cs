using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera mainCamera;
    public GridManager gridManager;

    void Update()
    {
        // Cast a ray from the mouse cursor position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits any collider
        if (Physics.Raycast(ray, out hit))
        {
            // Get the hit point's world position
            Vector3 hitPoint = hit.point;

            // Convert the world position to grid coordinates
            Vector2Int gridCoords = gridManager.GetGridCoordsFromWorld(hitPoint);

            // Highlight the corresponding tile on the grid
            gridManager.HighlightTile(gridCoords);

            // Draw a debug line in the Scene view
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            // Debug.Log($"X: {Mathf.Floor(hitPoint.x)} Z: {Mathf.Floor(hitPoint.z)}");
        }
        else
        {
            // Draw the ray in the Scene view if it doesn't hit anything
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
            gridManager.UnhighlightTile();
        }
    }
}
