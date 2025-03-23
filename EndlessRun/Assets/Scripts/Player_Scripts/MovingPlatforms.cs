using UnityEngine;
using UnityEngine.InputSystem.XR;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

public class MovingPlatforms : MonoBehaviour
{
    //array to hold waypoints
  [SerializeField] Transform[] waypoints; 

  // keeps track of current waypoint
  private int currentWaypointIndex = 0;



}
