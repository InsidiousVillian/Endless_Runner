using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //uses character controller unity function
   private CharacterController controller;
    private Vector3 playerVelocity;
    public AudioClip DeathSound;
    public GameManager gameManager;

    private bool isDead;

    //variables to hold player speed, strafe speed, constant forward speed, jump height, gravity values. all can be changed in inspector of object
    [SerializeField] float strafeSpeed = 2.0f;
    [SerializeField] float constantForwardSpeed = 5.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;
    public static PlayerMovement instance;  
    [SerializeField] private GameObject[] obstacles;  


    private void Start()
    {

        //uses charactercontroller function unity
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
      
        // Get only horizontal (left/right) input
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Create movement vector with constant forward motion and horizontal control
        Vector3 move = transform.forward * constantForwardSpeed + transform.right * horizontalInput * strafeSpeed;
        
        // Apply movement
        controller.Move(move * Time.deltaTime);

    
        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    // Handle collision with obstacles using CharacterController's built-in method
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collided object is one of the serialized obstacles
        foreach (GameObject obstacle in obstacles)
        {
            //changed to tag instead since previous version was only using the first obstacles set and when obstalces cloned no tags where being used
            if (hit.gameObject.CompareTag("obstacle") && !isDead)
            {
                Die();
                //break; // Exit the loop once collision is detected with an obstacle
                gameManager.gameOver();
            }
        }
    }
    // Method to handle player death
    void Die()
    {
        isDead = true;
        gameManager.gameOver();
        Debug.Log("Player died!");
        // Destroy the player game object or implement your death logic here
        Destroy(gameObject);
        AudioManager.Instance.PlaySound(DeathSound);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            Die();
            gameManager.gameOver();
            
        }
        if (other.gameObject.CompareTag("Sherif"))
        {
            Die();
            gameManager.gameOver();
        }
    }
}
     
    
