using UnityEngine;

public class BosslevelCamera : MonoBehaviour
{
    [SerializeField] private GameObject Villian;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(EnemyAI.Instance.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
