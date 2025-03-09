using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime *speed);
    }
}
