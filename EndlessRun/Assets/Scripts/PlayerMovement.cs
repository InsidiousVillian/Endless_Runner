using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float strafeSpeed = 2.0f;
    [SerializeField] float constantForwardSpeed = 5.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y < 0)
        {
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
}
     
    
