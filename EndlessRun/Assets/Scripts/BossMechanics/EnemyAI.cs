using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public GameObject cowBoy;
=======
    public Transform target;
    public static EnemyAI Instance;
   // public GameObject cowBoy;
>>>>>>> Stashed changes
=======
    public Transform target;
    public static EnemyAI Instance;
   // public GameObject cowBoy;
>>>>>>> Stashed changes
    public Transform player;
    public Transform Spwn;
    public float moveSpeed = 3f;
    public float timer = 0f;
    public float spawnerTime = 0f;
    public float delay = 3f;
    public float spawnDelay = 7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        transform.LookAt(target);
        //spawnerTime += Time.deltaTime;
        //if (spawnerTime >= spawnDelay)
        //{
        //    cowBoy.SetActive(true);
        //}
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void FixedUpdate()
    {

        if (player == null) return;
        timer += Time.fixedDeltaTime;
        if (timer >= delay)
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
