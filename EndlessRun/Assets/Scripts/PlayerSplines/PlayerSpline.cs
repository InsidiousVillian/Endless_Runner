using UnityEngine;
using UnityEngine.Splines;

public class PlayerSpline : MonoBehaviour
{
    [System.Serializable]
    public struct SplineTagPair
    {
        public string tag; // Tag of the trigger (e.g., "SplineA")
        public SplineContainer spline; // Corresponding spline
    }
    
    public SplineTagPair[] splines;
    public SplineContainer spline; // Reference to the spline
    public float speed = 5f; // Movement speed along the spline
    private float t = 0f; // Normalized position on the spline (0 to 1)
    private bool isFollowing = false; // Controls whether the player is on the spline
    private Rigidbody rb; // Optional: For physics-based movement
    private string lastSplineTag;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (splines.Length == 0) Debug.LogError("No splines assigned in SplineFollower!");
    }

    void Update()
    {
        Debug.Log("isFollowing: " + isFollowing);
        if (isFollowing && spline != null)
        {
            
            
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
        Debug.Log("Trigger hit by: " + other.gameObject.name + ", Tag: " + other.tag);
        foreach (var splinePair in splines)
        {
            if (other.CompareTag(spline.tag)) // Tag the trigger object
            {
                if (splinePair.spline == null)
                {
                    Debug.Log("Spline for tag " + splinePair.tag + "is null!");
                    return;
                }
                bool isSameSpline = spline == splinePair.spline && isFollowing;
                isFollowing = true;
                spline = splinePair.spline;
                lastSplineTag = splinePair.tag;
                if (rb != null)
                {
                    rb.useGravity = false; // Disable gravity while on spline
                    rb.isKinematic = true;
                }
                if (!isSameSpline)
                {
                    Debug.Log("Reattached to spline: " + spline.name + " at t: " + t + " (new spline or first attach)");
                }
                else
                {
                    Debug.Log("Resumed spline: " + spline.name + " at t: " + t + " (same spline)");
                }
                return;

            }
        }
        Debug.LogWarning("No spline found for tag: " + other.tag);

    }

    // Optional: Exit spline following
    void OnTriggerExit(Collider other)
    {
        foreach (var splinePair in splines)
        {
            if (other.CompareTag(splinePair.tag))
            {
                Debug.Log("player has left the trigger");
                isFollowing = false;
                if (rb != null)
                {
                    rb.useGravity = true; // Re-enable gravity
                    rb.isKinematic = false;
                }
            }
        }
        
    }
    void OnDrawGizmos()
    {
        if (isFollowing && spline != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spline.Spline.EvaluatePosition(t), 0.5f);
        }
    }
}

