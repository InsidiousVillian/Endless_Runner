using UnityEngine;
using UnityEngine.Events;


public class SplineTrigger : MonoBehaviour
{
    public UnityEvent Trigger;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Hit");
        Trigger.Invoke();
        
    }

}
