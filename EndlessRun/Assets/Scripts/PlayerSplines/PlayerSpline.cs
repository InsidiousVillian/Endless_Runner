using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerSpline : MonoBehaviour
{
    private SplineContainer spline;
    private float splineT = 0f; // Position along spline (0 to 1)
    private bool isOnSpline = false;
    private Rigidbody rb;
    public float moveSpeed = 5f; // Speed along the spline

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a SplineContainer
        spline = other.GetComponent<SplineContainer>();
        if (spline != null)
        {
            isOnSpline = true;
           
            // Optionally, snap player to the nearest point on the spline
            SplineUtility.GetNearestPoint(spline.Spline, transform.position, out _, out splineT);
        }
    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.GetComponent<SplineContainer>() == spline)
    //    {
    //        isOnSpline = false;
            
    //        spline = null;
    //    }
    //}

    void Update()
    {
        if (isOnSpline && spline != null)
        {
            // Get input to move along the spline
            float input = Input.GetAxis("Horizontal"); // Adjust based on your input
            splineT += input * moveSpeed * Time.deltaTime / spline.Spline.GetLength();
            splineT = Mathf.Clamp01(splineT); // Keep t between 0 and 1

            // Evaluate position and tangent on the spline
            Vector3 position = spline.EvaluatePosition(splineT);
            Vector3 tangent = spline.EvaluateTangent(splineT);

            // Move player to spline position
            transform.position = position;

            // Optionally, rotate player to face spline direction
            if (tangent != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(tangent);
            }
        }
    }
}

