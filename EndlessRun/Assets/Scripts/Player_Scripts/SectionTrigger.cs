using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject runningSection;
    private bool hasTrigger = false;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("trigger") && !hasTrigger){
            Instantiate(runningSection);
            hasTrigger = true;
        }
    }
    public void ResetTrigger(){
        hasTrigger = false;
    }
}
