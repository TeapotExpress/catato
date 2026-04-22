using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatArms : MonoBehaviour
{
    [SerializeField] Transform p, lookPoint, lookat;
    public LayerMask skibidi;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        p.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(p.position, Camera.main.transform.forward, out hit,Mathf.Infinity, skibidi))
        {
            lookPoint.transform.position = hit.point;
            
        }
        transform.LookAt(lookat.position);
    }
}
