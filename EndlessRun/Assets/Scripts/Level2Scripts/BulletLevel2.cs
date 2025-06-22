using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletLevel2 : MonoBehaviour
{
     private Vector3 moveDirection;
    public float bulletSpeed = 100f;
    public AudioClip BottleDestory;
    
    private Vector3 velocity;

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

        if (MasterInfo.bottleCount >= 20)
        {
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
            MasterInfo.bottleCount += 1;
        }
    }
}
