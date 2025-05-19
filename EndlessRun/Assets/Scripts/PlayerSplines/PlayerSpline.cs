using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerSpline : MonoBehaviour
{
    [SerializeField] private SplineContainer spline; // Reference to the Spline Container
    [SerializeField] private float speed = 1f; // Movement speed along the spline
    private float t = 0f; // Normalized distance along the spline (0 to 1)

    private bool isColliding = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SplineTrigger"))
        {
            isColliding = true;
        }
        
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("SplineTrigger"))
    //    {
    //        isColliding = false;
    //    }
    //}
    void Update()
    {
        if (isColliding == true)
        {
            // Increment the spline parameter based on speed and time
            t += speed * Time.deltaTime / spline.Spline.GetLength();
            t = Mathf.Repeat(t, 1f); // Loop back to 0 when reaching the end

            // Evaluate the spline to get the position and direction
            spline.Evaluate(t, out float3 position, out float3 tangent, out float3 up);

            // Move the object to the spline position
            transform.position = position;

            // Optional: Orient the object to face the spline’s tangent
            transform.rotation = Quaternion.LookRotation(tangent, up);
        }
        if(t >= 1)
        {
            
        }
        
    }
    
    
}

