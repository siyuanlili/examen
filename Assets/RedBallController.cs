using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallController : MonoBehaviour
{
    public GameObject redBarrier;
    public static bool isBarrierOpen = false;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = redBarrier.transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    ToggleBarrier();
                }
            }
        }
    }

    void ToggleBarrier()
    {
        if (isBarrierOpen)
        {
            redBarrier.transform.rotation = initialRotation;
        }
        else
        {
            redBarrier.transform.Rotate(Vector3.forward, 90f); 
        }
        isBarrierOpen = !isBarrierOpen;
    }
}
