using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorChanger : MonoBehaviour
{
    public Material flatMaterial;
    public Material slopeMaterial;
    public Material emissiveMaterial;
    private Renderer ballRenderer;

    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flat"))
        {
            ballRenderer.material = flatMaterial;
            SetEmissiveColor(Color.blue);
        }
        else if (collision.gameObject.CompareTag("Slope"))
        {
            ballRenderer.material = slopeMaterial;
            SetEmissiveColor(Color.yellow);
        }
    }

    void SetEmissiveColor(Color color)
    {
        ballRenderer.material.SetColor("_EmissionColor", color);
    }
}
