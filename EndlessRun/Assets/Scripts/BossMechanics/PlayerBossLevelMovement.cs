using UnityEngine;
using UnityEngine.Splines;

public class PlayerBossLevelMovement : MonoBehaviour
{
    
    public SplineContainer splineContainer;
    public float moveSpeed = 0.2f; // Speed of movement

    private float t = 0f; // Position along spline (0=start, 1=end)
    void Start()
    {
        if (splineContainer != null)
        {
            // Start at beginning of spline
            SplineUtility.Evaluate(splineContainer.Spline, 0f, out var position, out var tangent, out var up);
            transform.position = position;
            transform.rotation = Quaternion.LookRotation(tangent, up);
        }
    }
    void Update()
    {
        if (splineContainer == null || splineContainer.Spline == null)
            return;

        // Keyboard input
        float input = Input.GetAxis("Horizontal"); // Left (-1) or Right (1) arrow or A/D keys
        t += input * moveSpeed * Time.deltaTime;
        t = Mathf.Clamp01(t); // Keep t between 0 and 1

        // Get spline position and rotation
        SplineUtility.Evaluate(splineContainer.Spline, t, out var position, out var tangent, out var up);

        // Move and rotate object
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(tangent, up);
    }
}

