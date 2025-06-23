using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletLevel2 : MonoBehaviour
{
     private Vector3 moveDirection;
    public float bulletSpeed = 100f;
    public AudioClip BottleDestory;
    
    private Vector3 velocity;

    private FinishPoint finishPoint;


    void Start()
    {
        Destroy(gameObject, 2f);
    }

    public void Initialize(Vector3 directionVelocity)
    {
        velocity = directionVelocity;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        if (MasterInfoLevel2.BottleCount >= 15)
        {
            Debug.Log("Will load new level");
            SceneManager.LoadScene("BossLevel");
            //Kians Scene must be loaded here using SceneManager.LoadScene(Kians Scenes name);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bottle"))
        {
            Debug.Log("bottle count added here");
            AudioManager.Instance.PlaySound(BottleDestory);
            MasterInfoLevel2.BottleCount += 1;
        }
    }
}
