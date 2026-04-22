using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WeedmanController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;
    [SerializeField] SpriteRenderer spriteRenderer;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        Vector3 direction = (target.transform.position - transform.position).normalized;
        // vertical is multiplied by radian of camera angle to equalize both directions
        Vector3 move = new Vector3(direction.x, 0, direction.z * 2.217f);
        rb.AddForce(move * speed);
    }
}
