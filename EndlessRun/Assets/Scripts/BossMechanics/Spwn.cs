using System.Collections;
using UnityEngine;

public class Spwn : MonoBehaviour
{
    public GameObject targetObject;
    public float delay = 2f;

    void Start()
    {
        StartCoroutine(SetActiveAfterDelay());
    }

    IEnumerator SetActiveAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(true); // Works even if targetObject was initially inactive
    }

}
