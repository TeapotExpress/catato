using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float speed = 10;
    public int exp = 1;
    private GameObject player;
    [SerializeField] private bool isBigRed = false;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (isBigRed) exp = (int)player.GetComponent<CatExp>().expNeeded;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(player.transform.position, transform.position)<9)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position,speed*Time.deltaTime);
        }
        if(Vector3.Distance(player.transform.position, transform.position)<1)
        {
            player.GetComponent<CatExp>().AddExp(exp);
            Destroy(gameObject);
        }
    }
}
