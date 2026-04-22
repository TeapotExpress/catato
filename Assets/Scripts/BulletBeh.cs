using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour
{
    private int howManyTimesHasItHitAnEnemy=1;
    public GameObject splash;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag=="Enemy")
        {
            GameObject newSplash = Instantiate(splash,transform.position,Quaternion.identity);
            other.transform.GetComponent<EnemyHp>().DealHp(10);
            other.transform.GetComponent<Rigidbody>().AddForce(transform.forward*10,ForceMode.Impulse);
            if (howManyTimesHasItHitAnEnemy >= PlayerPrefs.GetFloat("DMG") / 2)
                transform.position = new Vector3(0, -99, 0);
            else
                howManyTimesHasItHitAnEnemy++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
