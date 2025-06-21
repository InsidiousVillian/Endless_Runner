using UnityEngine;
using UnityEngine.Splines;

public class SplineInstantiator : MonoBehaviour
{
    public SplineContainer splineContainer; // Reference to the spline
    public GameObject prefabToInstantiate;
    public int numberOfInstances = 10;
    public float spacing = 10f;

    void Start()
    {
        PlaceObjectsAlongSpline();
    }

    void PlaceObjectsAlongSpline()
    {
        if (splineContainer == null || prefabToInstantiate == null)
            return;

        Spline spline = splineContainer.Spline;

        for (int i = 0; i < numberOfInstances; i++)
        {
            float t = i / (float)(numberOfInstances - 1); // Normalized [0, 1]
            Vector3 position = spline.EvaluatePosition(t);
            Quaternion rotation = Quaternion.LookRotation(spline.EvaluateTangent(t)); // optional facing
            Instantiate(prefabToInstantiate, position, rotation, transform);
        }
    }
}

