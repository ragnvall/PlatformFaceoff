using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Shooting : MonoBehaviour
{
    public Gun[] gun;
    public Transform GunSpawnPoint;
    PhotonView view;
    GameObject ActiveGunInstance;
    Gun activeGun;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            ActiveGunInstance = PhotonNetwork.Instantiate(gun[0].gunPrefab.name, GunSpawnPoint.transform.position, Quaternion.identity);
            activeGun = gun[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            ActiveGunInstance.transform.SetPositionAndRotation(GunSpawnPoint.position, GunSpawnPoint.rotation);
            ActiveGunInstance.transform.forward = cam.transform.forward;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchGun();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                fire();
            }
        }
        
    }
    public void SwitchGun()
    {
        foreach(Gun guns in gun)
        {
            //print(guns.gunName + " " + activeGunName);
            if(guns.gunName != activeGun.gunName)
            {
                PhotonNetwork.Destroy(ActiveGunInstance);
                ActiveGunInstance = PhotonNetwork.Instantiate(guns.gunPrefab.name, GunSpawnPoint.transform.position, Quaternion.identity);
                activeGun = guns;
                break;
            }
        }
    }
    public void fire()
    {
        Transform firePoint = ActiveGunInstance.transform.GetChild(0).transform;
        //Vector3 offset = new Vector3(firePoint.position.x + 2, firePoint.position.y, firePoint.position.z);
        GameObject bullet = PhotonNetwork.Instantiate(activeGun.bulletPrefab.name, firePoint.position,
            firePoint.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(ActiveGunInstance.transform.forward * activeGun.bulletSpeed);
    }
}
