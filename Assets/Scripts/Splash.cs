using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);   
        Destroy(gameObject,5);    
    }
}
