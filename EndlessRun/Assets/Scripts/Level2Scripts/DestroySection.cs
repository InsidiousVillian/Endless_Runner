using UnityEngine;

public class DestroySection : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 7f);
    }
     
}
