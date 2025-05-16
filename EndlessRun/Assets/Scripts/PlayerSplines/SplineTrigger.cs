using UnityEngine;
using UnityEngine.Events;


public class SplineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerHIT");
    }

}
