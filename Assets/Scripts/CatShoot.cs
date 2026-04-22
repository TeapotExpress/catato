using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShoot : MonoBehaviour
{
    public WeaponObject holdingObj;
    [SerializeField] private Transform turret, txt;

    public List<GameObject> bullets;

    private bool canShoot = true;

    int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBullets();
    }

    void SpawnBullets()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject newBullet = Instantiate(Resources.Load("Bullet") as GameObject);
            newBullet.transform.localScale = Vector3.zero;
            newBullet.transform.position = new Vector3(0, -99, 0);
            bullets.Add(newBullet);
        }
    }
    IEnumerator WeaponDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(Mathf.Clamp(holdingObj.shootDelay - PlayerPrefs.GetFloat("REL")/13,0.1f,999));
        canShoot = true;
    }
    void Shoot()
    {
        SFXManager.instance.PlaySFX("Pew", transform, float.NaN, Mathf.Clamp(1.1f - PlayerPrefs.GetFloat("DMG") * 0.1f, 0.5f, 1f));
        StartCoroutine(WeaponDelay());
        GameObject newBullet = bullets[j];
        newBullet.transform.position = turret.position;
        newBullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newBullet.GetComponent<Rigidbody>().AddForce(turret.forward * holdingObj.bulletSpeed, ForceMode.Impulse);
        newBullet.transform.localScale = Vector3.one * PlayerPrefs.GetFloat("DMG")/3;
        if (j < 99)
            j++;
        else
            j = 0;
    }
    // Update is called once per frame
    void Update()
    {
        txt.GetComponent<SpriteRenderer>().sprite = holdingObj.txt;
        if(Input.GetMouseButton(0) && canShoot) 
        {
            Shoot();
        }
    }
}
