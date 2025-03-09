using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //camera distance from player
    private Vector3 _offset;

    [SerializeField] private Transform target;

    //controls smoothness of camera
    [SerializeField] private float smoothTime;

    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        Vector3 targetPosition = transform.position -_offset;
   
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position -_offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime );
    }






}
