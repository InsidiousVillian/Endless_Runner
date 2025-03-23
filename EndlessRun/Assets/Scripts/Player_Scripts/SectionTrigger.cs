using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject runningSection;
    private bool hasTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("trigger") && !hasTrigger)
        {
            Instantiate(runningSection, new Vector3(1, 0, 28), Quaternion.identity);
            hasTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("trigger")){
            ResetTrigger();
        }
    } 
    public void ResetTrigger()
    {
        hasTrigger = false;
    }
}