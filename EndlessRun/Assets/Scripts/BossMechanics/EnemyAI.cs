using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) 
        {
            Vector3 direction = (player.position - transform.position).normalized;
            GetComponent<Rigidbody>().MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
