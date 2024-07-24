using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Public
    public float size = 1f; // Size of the plane
    public int gridSize = 10;
    public GameObject tilePrefab;
    // public Color tileColor = Color.white; // Default color

    // private MeshRenderer _meshRenderer;
    // private MeshFilter _meshFilter;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // _meshRenderer = gameObject.AddComponent<MeshRenderer>();
        // Material material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        // // Set the color of the material
        // material.SetColor("_BaseColor", tileColor);
        // _meshRenderer.material = material;
        // _meshFilter = gameObject.AddComponent<MeshFilter>();

        for (int z = 0, i = 0; z < gridSize; z++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                Vector3 position;
                position.x = x + 0.5f;
                position.y = 0f;
                position.z = z + 0.5f;

                GameObject cell = Instantiate<GameObject>(tilePrefab);
                cell.transform.SetParent(transform, false);
                cell.transform.localPosition = position;
            }
        }
    }

    //     void RenderGridTile()
    //     {
    //         Vector3[] verts = new Vector3[4]
    //         {
    //             new Vector3(0, 0, 0), // Bottom left
    //             new Vector3(size, 0, 0), // Bottom right
    //             new Vector3(0, 0, size), // Top left
    //             new Vector3(size, 0, size) // Top right
    //         };

    //         int[] tris = new int[6]
    // {
    //             // lower left triangle
    //             0, 2, 1,
    //             // upper right triangle
    //             2, 3, 1
    //         };

    //         Vector3[] normals = new Vector3[4]
    //         {
    //             Vector3.up,
    //             Vector3.up,
    //             Vector3.up,
    //             Vector3.up
    //         };

    //         Vector2[] uv = new Vector2[4]
    //         {
    //             new Vector2(0, 0),
    //             new Vector2(1, 0),
    //             new Vector2(0, 1),
    //             new Vector2(1, 1)
    //         };

    //         Mesh mesh = new Mesh
    //         {
    //             vertices = verts,
    //             triangles = tris,
    //             normals = normals,
    //             uv = uv
    //         };

    //         _meshFilter.mesh = mesh;
    //     }
}
