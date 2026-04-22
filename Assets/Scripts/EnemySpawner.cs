using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public List<GameObject> enemies;
    public List<GameObject> enemyPool1;
    public int enemyNumber=0;
    public int maxEnemies = 100;

    public int spawnCount = 40;

    public int range = 60;
    public float level = 0;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<100; i++)
        {
            GameObject newEnemy = Instantiate(enemies[Random.Range(0,enemies.Count)]);
            enemyPool1.Add(newEnemy);
        }
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);
        spawnCount = (int)(level*1.5f);
        level++;
        Vector3 dir = new Vector3(range,0,0);
        if (enemyNumber < maxEnemies)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                if (i < spawnCount * 0.25 && i > spawnCount * 0.1)
                    dir = new Vector3(-range, 0, 0);
                else if (i < spawnCount * 0.5)
                    dir = new Vector3(0, 0, range);
                else if (i < spawnCount * 0.75)
                    dir = new Vector3(0, 0, -range);


                enemyNumber++;
                if (enemyPool1[i].GetComponent<EnemyHp>().isDead)
                {
                    enemyPool1[i].GetComponent<EnemyHp>().Spawn(level/2f);
                    enemyPool1[i].transform.position = transform.position + dir+new Vector3(0,1,0);
                }

            }
        }
        StartCoroutine(Spawn());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
