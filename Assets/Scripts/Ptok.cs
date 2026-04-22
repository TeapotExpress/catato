using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptok : MonoBehaviour
{
    public GameObject d;

    IEnumerator bb()
    {
        d.transform.localPosition = Vector3.zero;
        yield return new WaitForSeconds(3);
        d.SetActive(true);
        StartCoroutine(bb());
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bb());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
