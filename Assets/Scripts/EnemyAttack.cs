using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private GameObject target;
    public int damage = 10;
    bool attacking = false;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.CompareTag("Player") && !attacking)
        {
            StartCoroutine(attack(target));
        }
    }



    public IEnumerator attack(GameObject attackTarget)
    {
        attacking = true;
        attackTarget.GetComponent<CatHp>().ChangeHP(-damage);
        yield return new WaitForSeconds(0.2f);
        attacking = false;
    }
}
