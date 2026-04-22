using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun/NewGun")]
public class WeaponObject : ScriptableObject
{
    public Sprite txt;
    public float reloadSpeed = 1;
    public float holdingSpeed = 1;
    public int ammoInMag = 7;
    public int maxAmmo = 90;
    public float shootDelay = 0.4f;
    public float bulletSpeed = 10;
}
