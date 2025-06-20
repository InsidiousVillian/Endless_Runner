using Unity.Mathematics;
using UnityEngine;

public class UseHighNoonPickup : MonoBehaviour
{
    public GameObject HighNoonItem;
    public HighNoonEffect highNoonEffect;
    public AudioClip HighNoonSoundEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            UseHighNoon();
        }
    }

    void UseHighNoon()
    {
        if(HighNoonPickup.highNoonList.Count > 0){
            HighNoonItem = HighNoonPickup.highNoonList[0];
            Debug.Log("using high noon");

            AudioManager.Instance.PlaySound(HighNoonSoundEffect);

            HighNoonPickup.highNoonList.RemoveAt(0);

            if(highNoonEffect != null){
                highNoonEffect.TriggerHighNoon();
            }
            else{
                Debug.LogError("not set");
            }
        }
        else{
            Debug.LogError("Item not being used");
        }
    }
}