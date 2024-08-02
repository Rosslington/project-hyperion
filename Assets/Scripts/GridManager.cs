using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Public
    public float size = 1f; // Size of the plane
    public int gridSize = 10;
    public GameObject tilePrefab;
    public GameObject highlightPrefab;
    public Color defaultColor;
    public Color highlightColor;    // Store the generated tiles in a dictionary for quick access
    private Dictionary<Vector2Int, GameObject> tiles = new Dictionary<Vector2Int, GameObject>();

    // Reference to the currently highlighted tile
    private GameObject currentlyHighlightedTile;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int z = 0; z < gridSize; z++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                Vector3 position;
                position.x = x + 0.5f;
                position.y = 0f;
                position.z = z + 0.5f;

                GameObject cell = Instantiate(tilePrefab);
                cell.transform.SetParent(transform, false);
                cell.transform.localPosition = position;
                // Name the tile using its grid coordinates
                cell.name = $"Tile_{x}_{z}";

                // Store the tile in the dictionary with grid coordinates as the key
                tiles[new Vector2Int(x, z)] = cell;
            }
        }
    }

    // Method to highlight a tile at the given grid coordinates
    public void HighlightTile(Vector2Int tileCoords)
    {
        // Check if the tile exists in the dictionary
        if (tiles.TryGetValue(tileCoords, out GameObject tile))
        {
            // Unhighlight the previously highlighted tile if necessary
            if (currentlyHighlightedTile != null && currentlyHighlightedTile != tile)
            {
                UnhighlightTile();
            }

            // move highlight ontop of tile
            highlightPrefab.SetActive(true);
            highlightPrefab.transform.position = new Vector3(tileCoords.x + 0.5f, 0.001f, tileCoords.y + 0.5f);

            currentlyHighlightedTile = tile; // Update the currently highlighted tile reference
        }
    }
    // Method to unhighlight the currently highlighted tile
    public void UnhighlightTile()
    {
        if (currentlyHighlightedTile != null)
        {
            highlightPrefab.SetActive(false);

            currentlyHighlightedTile = null; // Clear the reference
        }
    }
    // Method to convert world coordinates to grid coordinates
    public Vector2Int GetGridCoordsFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x);
        int z = Mathf.FloorToInt(worldPosition.z);

        return new Vector2Int(x, z);
    }
}
