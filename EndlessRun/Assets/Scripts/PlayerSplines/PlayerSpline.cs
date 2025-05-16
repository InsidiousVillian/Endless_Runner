using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerSpline : MonoBehaviour
{
    [System.Serializable]
    public struct SplineTrigger
    {
        public SplineContainer container; // SplineContainer for the spline
        public int splineIndex; // Index of the spline in the container
        public Collider trigger; // Trigger collider to start following
    }

    public List<SplineTrigger> splines; // List of splines and their triggers
    public float speed = 5f; // Speed along each spline
    private GameObject player; // Reference to the player
    private bool isFollowingSpline = false; // Is the player on a spline?
    private float t = 0f; // Current spline interpolation (0 to 1)
    private int currentSplineIndex = -1; // Index of the current spline in the list
    private PlayerMovement playerController; // Optional: Reference to player input script

    void Start()
    {
        // Find the player by tag
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerMovement>();

        // Ensure all triggers are set up correctly
        foreach (var spline in splines)
        {
            if (spline.trigger != null)
                spline.trigger.gameObject.AddComponent<SplineTriggerHandler>().Initialize(this, splines.IndexOf(spline));
        }
    }

    // Called by SplineTriggerHandler when player enters a trigger
    public void StartFollowingSpline(int splineIndex)
    {
        if (isFollowingSpline) return; // Prevent switching if already following

        currentSplineIndex = splineIndex;
        isFollowingSpline = true;
        t = 0f;

        // Disable player input
        if (playerController != null)
            playerController.enabled = false;
    }

    void Update()
    {
        if (!isFollowingSpline || currentSplineIndex < 0 || player == null) return;

        var currentSpline = splines[currentSplineIndex];
        var spline = currentSpline.container.Splines[currentSpline.splineIndex];

        // Move along the spline
        t += Time.deltaTime * speed / spline.GetLength();
        if (t >= 1f)
        {
            // Reached the end of the spline
            isFollowingSpline = false;
            t = 1f;
            currentSplineIndex = -1;

            // Re-enable player input
            if (playerController != null)
                playerController.enabled = true;
            return;
        }

        // Evaluate the spline
        SplineUtility.Evaluate(spline, t, out float3 position, out float3 direction, out float3 up);
        player.transform.position = position;
        player.transform.rotation = Quaternion.LookRotation(direction, up);

        float minDistance = float.MaxValue;
        int closestSplineIndex = -1;
        for (int i = 0; i < splines.Count; i++)
        {
            SplineUtility.GetNearestPoint(splines[i].container.Splines[splines[i].splineIndex], player.transform.position, out _, out float distance);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestSplineIndex = i;
            }
        }
        if (closestSplineIndex >= 0)
            StartFollowingSpline(closestSplineIndex);
    }
    
}


// Helper component for trigger handling
public class SplineTriggerHandler : MonoBehaviour
{
    private PlayerSpline manager;
    private int splineIndex;

    public void Initialize(PlayerSpline manager, int index)
    {
        this.manager = manager;
        this.splineIndex = index;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.StartFollowingSpline(splineIndex);
        }
    }
}

