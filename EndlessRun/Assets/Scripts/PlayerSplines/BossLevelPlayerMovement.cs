using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Splines;

public class BossLevelPlayerMovement : MonoBehaviour
{
    [SerializeField]
    private SplineContainer SplineContainer;
    [SerializeField]
    private float speed = 1f;
    private bool isColliding = false;
    private float closestT = 0f;
    private float t = 0f;
    public float moveSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isColliding == true)
        {
            float input = Input.GetAxis("Horizontal");
            t += input * moveSpeed * Time.deltaTime;
            t = Mathf.Clamp01(t);
            // Increment the spline parameter based on speed and time
            t += speed * Time.deltaTime / SplineContainer.Spline.GetLength();
            t = Mathf.Repeat(t, 1f); // Loop back to 0 when reaching the end

            // Evaluate the spline to get the position and direction
            SplineContainer.Evaluate(t, out float3 position, out float3 tangent, out float3 up);

            // Move the object to the spline position
            transform.position = position;

            // Optional: Orient the object to face the spline’s tangent
            transform.rotation = Quaternion.LookRotation(tangent, up);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SplineTrigger"))
        {
            isColliding = true;
            
        }
    }
    
}
