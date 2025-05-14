using UnityEngine;
using UnityEngine.Splines;

public class PlayerSpline : MonoBehaviour
{
    public SplineContainer splineContainer;
    public float speed = 1f;
    private float t = 0f;
    private bool followSpline = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }
    void Update()
    {

        if (followSpline)
        {
            t += Time.deltaTime * speed;
            t = Mathf.Clamp01(t);
            transform.position = splineContainer.Spline.EvaluatePosition(t);
            Vector3 direction = splineContainer.Spline.EvaluateTangent(t);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttachTrigger"))
        {
            followSpline = true;
        }
        if (other.CompareTag("DetachTrigger")) // Check if the collider is the detach trigger
        {
            followSpline = false; // Stop following the spline
        }
    }
}


