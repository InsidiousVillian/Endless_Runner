using System.Runtime.InteropServices;
using UnityEngine;

public class MovementLevel2 : MonoBehaviour
{
     public float speed = 5f;
    void Update()
    {
        // Move player to the right
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
