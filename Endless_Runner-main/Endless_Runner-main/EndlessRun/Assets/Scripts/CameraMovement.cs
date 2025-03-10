using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     //camera distance from player
    private Vector3 _offset;
    
    [SerializeField] private Transform target;
    
    //controls smoothness of camera
    [SerializeField] private float smoothTime = 0.4f;
    
    private Vector3 _currentVelocity = Vector3.zero;
    
    private void Start()
    {
        // Calculate the initial offset between camera and target
        if (target != null)
        {
            _offset = transform.position - target.position;
        }
        else
        {
            Debug.LogError("No target assigned to camera follow script!");
        }
    }
    
    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position by adding the offset to the target's position
            Vector3 targetPosition = target.position + _offset;
            
            // Smoothly move the camera to that position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        }
    }

}
