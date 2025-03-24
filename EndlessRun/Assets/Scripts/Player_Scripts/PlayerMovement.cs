using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //uses character controller unity function
   private CharacterController controller;
    private Vector3 playerVelocity;

    //checks if player is grounded using unity function
    private bool groundedPlayer;


    //variables to hold player speed, strafe speed, constant forward speed, jump height, gravity values. all can be changed in inspector of object

    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float strafeSpeed = 2.0f;
    [SerializeField] float constantForwardSpeed = 5.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;
    
    [SerializeField] private GameObject[] obstacles; // Array to hold obstacle references
    private void Start()
    {

        //uses charactercontroller function unity
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        //checks if player is grounded, if not sets y velocity to 0 - stops player from double jumping or constantly going up 
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y < 0)
        {
            //Debug.Log("player cannot jump");
            playerVelocity.y = 0;
        }

        // Get only horizontal (left/right) input
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Create movement vector with constant forward motion and horizontal control
        Vector3 move = transform.forward * constantForwardSpeed + transform.right * horizontalInput * strafeSpeed;
        
        // Apply movement
        controller.Move(move * Time.deltaTime);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

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
            if (hit.gameObject == obstacle)
            {
                Die();
                break; // Exit the loop once collision is detected with an obstacle
            }
        }
    }
    // Method to handle player death
    void Die()
    {
        Debug.Log("Player died!");
        // Destroy the player game object or implement your death logic here
        Destroy(gameObject);
    }
}
     
    
