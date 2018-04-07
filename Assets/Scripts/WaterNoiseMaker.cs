using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNoiseMaker : MonoBehaviour {

    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;

    float xOffset;
    float yOffset;
    MeshFilter filter;

	void Start () {
        filter = GetComponent<MeshFilter>();
        MakeNoise();
	}
	
	void Update () {
        xOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;

        MakeNoise();
        //filter.mesh.RecalculateNormals();
    }

    void MakeNoise() {
        Vector3[] vertices = filter.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++) {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power;
        }

        filter.mesh.vertices = vertices;
    }

    float CalculateHeight(float x, float y) {
        float xCord = x * scale + xOffset;
        float yCord = y * scale + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
