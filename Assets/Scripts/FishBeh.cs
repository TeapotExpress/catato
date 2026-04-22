using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FishBeh : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    public IEnumerator Dash()
    {
        
        yield return new WaitForSeconds(2);
        Vector3 target = player.transform.position;
        yield return new WaitForSeconds(1);
        Vector3 direction = (target - transform.position).normalized;
        // vertical is multiplied by radian of camera angle to equalize both directions
        Vector3 move = new Vector3(direction.x, 0, direction.z * 2.217f);
        rb.AddForce(move * 100, ForceMode.Impulse);
        StartCoroutine(Dash());
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Dash());
    }
    private void OnEnable()
    {
        StartCoroutine(Dash());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
