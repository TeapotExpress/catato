using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public GameObject glow, ragdoll;


    public int exp=1;
    public float hp=1;

    public bool isDead=false;
    public void DealHp(float amount)
    {
        hp-=amount;
        StartCoroutine(Flash());
    }
    public void Die()
    {
        SFXManager.instance.PlaySFX("Kill", transform, float.NaN, Random.Range(0.98f, 1.02f));
        EnemySpawner.instance.enemyNumber--;
        isDead=true;
        GameObject newRagdoll = Instantiate(ragdoll, transform.position, Quaternion.identity);
        newRagdoll.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity*2;
        GameObject newExp = Instantiate(Resources.Load("exp") as GameObject);
        newExp.transform.position = transform.position;
        gameObject.SetActive(false);
    }
    public void Spawn(float setHp)
    {
        gameObject.SetActive(true);
        hp = setHp;
        isDead = false;
        DealHp(0);
    }
    void Start()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
    IEnumerator Flash()
    {
        glow.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        glow.SetActive(false);
    }
    void Update()
    {

        if(hp<=0 && !isDead)
        {
            Die();
        }
    }
}
