using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public delegate void PickupItem();

    //event declared
    public static event PickupItem OnPickupItem;

    public AudioClip itemPickupSound;
    //gun reference
    public GameObject gun; 
    
    //shared list to hold guns
    public static List<GameObject> guns = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            OnPickupItem?.Invoke(); 
        }     
    }

    private void OnEnable()
    {
        //subscriber
        OnPickupItem += AddItem;        
    }

    private void OnDisable(){
        //unsubscribe
        OnPickupItem -= AddItem;
    }

    public void AddItem()
    {

        //add the gun to the list
        guns.Add(gun);
        Destroy(gameObject);
        Debug.Log("Gun picked up");
        AudioManager.Instance.PlaySound(itemPickupSound);
    }
}
