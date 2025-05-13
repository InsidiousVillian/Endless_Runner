using System.Collections.Generic;
using UnityEngine;

public class HighNoonPickup : MonoBehaviour
{
    public delegate void PickupHighNoon();
    public static event PickupHighNoon OnPickupHighNoon;

    public GameObject highNoon;

    public static List<GameObject> highNoonList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnPickupHighNoon?.Invoke();
        }
    }

    private void OnEnable()  
    {
        OnPickupHighNoon += AddHighNoon;
    }

    private void OnDisable()
    {
        OnPickupHighNoon -= AddHighNoon;
    }

    void AddHighNoon()
    {
        highNoonList.Add(highNoon);
        Destroy(gameObject);
        Debug.Log("HighNoon has been picked up");
    }
}
