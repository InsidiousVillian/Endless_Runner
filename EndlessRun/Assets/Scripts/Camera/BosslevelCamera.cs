using UnityEngine;

public class BosslevelCamera : MonoBehaviour
{
    [SerializeField] private GameObject Villian;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
