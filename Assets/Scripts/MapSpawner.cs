using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public List<GameObject> obj;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1499; i++)
        {
            SpawnStuff();
        }
    }
    void SpawnStuff()
    {
       
        GameObject newB = Instantiate(obj[Random.Range(0,obj.Count)]);
        newB.transform.position = new Vector3(Random.Range(-1333,1333),0.2f,Random.Range(-1333,1333));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
