using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gun
{
    public string gunName;
    public GameObject gunPrefab;
    public GameObject bulletPrefab;
    public float fireRate;
    public float maxAmmo;
}
