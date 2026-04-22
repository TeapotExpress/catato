using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatHp : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    private float maxHP = 100;
    [SerializeField] private HpBar hpBar;
    [SerializeField] private GameObject DeadOverlay;
    // Start is called before the first frame update
    private void Start()
    {
        SetHP(maxHP);
    }
    public void ChangeHP(float hpToAdd)
    {
        if (hp + hpToAdd < maxHP) hp += hpToAdd;
        else hp = maxHP;
        hpBar.SetHPBarValue(hp / maxHP);

        if (hp <= 0) Die();
    }
    public void SetHP(float hpToSet)
    {
        hp = hpToSet;
        hpBar.SetHPBarValue(hp / maxHP);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        DeadOverlay.SetActive(true);
    }
}