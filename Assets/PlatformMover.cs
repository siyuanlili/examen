using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 2f;
    public float waitTime = 1f;
    public float smoothTime = 0.3f;

    private int currentPointIndex = 0;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (points.Length > 0)
        {
            transform.position = points[0].position;
            StartCoroutine(MoveToNextPoint());
        }
    }

    IEnumerator MoveToNextPoint()
    {
        while (true)
        {
            Vector3 targetPosition = points[currentPointIndex].position;

            // Move towards the target position with smoothing
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, moveSpeed);
                yield return null;
            }

            // Snap to the target position to avoid any minor discrepancies
            transform.position = targetPosition;

            // Wait for a specified time at the point
            yield return new WaitForSeconds(waitTime);

            // Move to the next point
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }
}
