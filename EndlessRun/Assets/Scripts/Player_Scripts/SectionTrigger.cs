using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    //field for player to set running section so it can be instatiated, this can be done in inspector
    public GameObject runningSection;

    //sets trigger to be flase at start
    private bool hasTrigger = false;

    /*when player hits trigger / empty game object and 
    the trigger id false then it will instatiate a new running section 
    at the location specified*/





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