using UnityEngine;
using UnityEngine.Splines;

public class PlayerSpline : MonoBehaviour
{
    public SplineContainer spline; // Reference to the spline
    public float speed = 5f; // Movement speed along the spline
    private float t = 0f; // Normalized position on the spline (0 to 1)
    private bool isFollowing = false; // Controls whether the player is on the spline
    private Rigidbody rb; // Optional: For physics-based movement

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log("isFollowing: " + isFollowing);
        if (isFollowing)
        {
            // Get input for forward/backward movement
            
            t += speed * Time.deltaTime / spline.Spline.GetLength(); // Normalize speed by spline length
            t = Mathf.Clamp01(t); // Keep t between 0 and 1

            // Evaluate position and direction on the spline
            Vector3 position = spline.Spline.EvaluatePosition(t);
            Vector3 forward = spline.Spline.EvaluateTangent(t);

            // Move the player
            transform.position = position;
            if (forward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(forward, Vector3.up); // Align to spline direction
            }
        }
    }

    // Detect collision with a trigger to start following the spline
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SplineTrigger")) // Tag the trigger object
        {
            Debug.Log("trigger is working");
            isFollowing = true;
            if (rb != null)
            {
                rb.useGravity = false; // Disable gravity while on spline
            }
        }
    }

    // Optional: Exit spline following
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("SplineTrigger"))
    //    {
    //        Debug.Log("player has left the trigger");
    //        isFollowing = false;
    //        if (rb != null)
    //        {
    //            rb.useGravity = true; // Re-enable gravity
    //        }
    //    }
    //}
}

