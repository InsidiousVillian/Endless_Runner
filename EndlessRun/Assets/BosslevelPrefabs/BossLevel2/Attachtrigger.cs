using UnityEngine;
using UnityEngine.Splines;

public class Attachtrigger : MonoBehaviour
{
    public SplineContainer splineContainer; // Assign in Inspector
    public float moveSpeed = 1.0f;
    private float splinePosition = 0f;
    private bool followSpline = false;

    void Update()
    {
        if (followSpline)
        {
            // Move forward along spline
            splinePosition += moveSpeed * Time.deltaTime;

            // Clamp to end of spline
            splinePosition = Mathf.Clamp01(splinePosition);

            // Set position along spline
            transform.position = splineContainer.EvaluatePosition(splinePosition);

            // Optionally set rotation
            transform.forward = splineContainer.EvaluateTangent(splinePosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SplineTrigger"))
        {
            followSpline = true;
            splinePosition = 0f; // Reset start if needed
        }
    }

    // Optional: detach when exiting another trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Detachtrigger"))
        {
            followSpline = false;

        }
    }

}
