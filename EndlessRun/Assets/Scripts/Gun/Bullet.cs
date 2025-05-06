using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody body;
   
    void Start()
    {
        //gets rigidbody component
        body = GetComponent<Rigidbody>();
        body.linearVelocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstacle")){
            //destroys obstacle
            Destroy(other.gameObject);
            //destroys bullet
            Destroy(this.gameObject);
        }
    }

}
