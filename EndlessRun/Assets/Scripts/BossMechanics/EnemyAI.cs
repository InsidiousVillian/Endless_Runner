using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float timer = 0f;
    public float delay = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(PlayerMovement.instance.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null) return;

        timer += Time.fixedDeltaTime;
        if(timer >= delay)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
            
        }
        
    }
}
