using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSomething : MonoBehaviour
{
    public Transform target;
    public float speed = 10;
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed*Time.deltaTime);
    }
}
