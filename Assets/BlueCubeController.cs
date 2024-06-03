using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeController : MonoBehaviour
{
    public GameObject blueDoorLeft;
    public GameObject blueDoorRight;
    private bool areDoorsOpen = false;
    private Quaternion blueDoorLeftInitialRotation;
    private Quaternion blueDoorRightInitialRotation;

    void Start()
    {
        blueDoorLeftInitialRotation = blueDoorLeft.transform.rotation;
        blueDoorRightInitialRotation = blueDoorRight.transform.rotation;
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
                    ToggleDoors();
                }
            }
        }
    }

    void ToggleDoors()
    {
        if (RedBallController.isBarrierOpen)
        {
            if (areDoorsOpen)
            {
                blueDoorLeft.transform.Rotate(Vector3.up, -90f);
                blueDoorRight.transform.Rotate(Vector3.up, 90f);
            }
            else
            {
                blueDoorLeft.transform.Rotate(Vector3.up, 90f);
                blueDoorRight.transform.Rotate(Vector3.up, -90f);
            }
            areDoorsOpen = !areDoorsOpen;
        }
        else
        {
            StartCoroutine(ShakeBlueDoors());
        }
    }

    System.Collections.IEnumerator ShakeBlueDoors()
    {
        blueDoorLeft.transform.Rotate(Vector3.up, 15f);
        blueDoorRight.transform.Rotate(Vector3.up, -15f);
        yield return new WaitForSeconds(0.2f);
        blueDoorLeft.transform.rotation = blueDoorLeftInitialRotation;
        blueDoorRight.transform.rotation = blueDoorRightInitialRotation;
    }
}
