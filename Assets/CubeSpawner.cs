using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float radius = 5f;
    public Gradient colorGradient;

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfCubes;
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);

            float colorValue = (float)i / numberOfCubes;
            Color color = colorGradient.Evaluate(colorValue);
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            cubeRenderer.material.color = color;
        }
    }
}
