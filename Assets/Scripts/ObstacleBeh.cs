using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBeh : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        Die();
    }
    public void Die()
    {
        GameObject newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
        Destroy(gameObject);
    }

}
