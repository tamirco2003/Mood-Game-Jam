using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMeshGenerator : MonoBehaviour {

    public float size = 1;
    public float gridSize = 16;

    MeshFilter filter;

    void Start() {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
    }

    Mesh GenerateMesh() {
        Mesh mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();

        for (int x = 0; x <= gridSize; x++) {
            for (int y = 0; y <= gridSize; y++) {
                vertices.Add(new Vector3(-size / 2 + size * (x / gridSize), 0, -size / 2 + size * (y / gridSize)));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / gridSize, y / gridSize));
            }
        }

        List<int> triangles = new List<int>();
        int vertCount = (int) gridSize + 1;

        for (int i = 0; i < vertCount * vertCount - vertCount; i++) {
            if ((i + 1) % vertCount == 0) {
                continue;
            }

            triangles.AddRange(new List<int>() {
                i + 1 + vertCount, i + vertCount, i,
                i, i + 1, i + 1 + vertCount
            });
        }

        mesh.SetVertices(vertices);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);

        return mesh;
    }
}
