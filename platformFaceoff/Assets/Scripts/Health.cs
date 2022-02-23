using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Health : MonoBehaviour
{

    public float health = 100;
    private float h;
    PhotonView view;
    // Start is called before the first frame update
    private void Start()
    {
        view = GetComponent<PhotonView>();
        h = health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (view.IsMine)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                h -= collision.gameObject.GetComponent<bulletFire>().bulletDamage;
                Debug.Log("Shot");
            }
        }
        
    }
    private void Update()
    {
        if (view.IsMine)
        {
            if (h <= 0)
            {
                GetComponent<movement>().respawn(new Vector3(0,3,0));
                h = health;
            }
        }
    }
}
