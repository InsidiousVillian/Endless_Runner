using Unity.Mathematics;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject itemToUse;
    public GameObject Bullet;
    public GameObject bulletSpawner;
    public AudioClip AttackSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            UseGun();
        }
    }

    void UseGun(){
        if (ItemPickup.guns.Count > 0){
            //grabbing the first gun in the list
            itemToUse = ItemPickup.guns[0];
            Debug.Log("using gun");
            //spawns bullet
            Instantiate(Bullet, bulletSpawner.transform.position, quaternion.identity);

            AudioManager.Instance.PlaySound(AttackSound);

            //removes gun from list 
            ItemPickup.guns.RemoveAt(0);
        }
        else{
            Debug.Log("item is not beign used");
        }
    }
}
