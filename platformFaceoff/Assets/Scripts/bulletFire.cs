using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class bulletFire : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage = 25;
    Rigidbody rb;
    PhotonView view;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
        Destroy(gameObject, 3f);
        dir = transform.forward;
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            rb.AddForce(dir * bulletSpeed * Time.fixedDeltaTime);
        }
        
    }
}
