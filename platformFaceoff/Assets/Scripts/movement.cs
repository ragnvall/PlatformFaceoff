using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class movement : MonoBehaviour
{
    public float movespeed = 9;
    public float RespawnYpos = -10;
    public GameObject cam, cmvCam;
    private Rigidbody rb;

    private float inputx;
    private float inputy;

    private Quaternion targetRotation;
    Quaternion currentRotation;
    Vector3 moveDir;

    bool jump = false;
    bool canJump = false; //checks to see if the player is touching anything

    public float rotationFactoredPerFrame = 15.0f;
    public float jumpHeight = 10;
    public float maxSpeed = 50;

    PhotonView view;

   
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            Destroy(cam);
            Destroy(cmvCam);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            inputx = Input.GetAxis("Horizontal");
            inputy = Input.GetAxis("Vertical");
            currentRotation = transform.rotation;
            Vector3 projectedCameraForward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up);
            targetRotation = Quaternion.LookRotation(projectedCameraForward);
            moveDir = transform.forward * inputy + transform.right * inputx;
            if (Input.GetButtonDown("Jump") && canJump)
            {
                jump = true;

            }

            if (transform.position.y < RespawnYpos)
            {
                respawn(new Vector3(0, 3, 0));
            }
        }

    }
    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            if (jump && canJump)
            {
                rb.AddForce(transform.up * jumpHeight * movespeed * Time.fixedDeltaTime);
                jump = false;
                canJump = false;
            }
            //print(rb.velocity + " Ang Vel:" + rb.angularVelocity);
            Vector3 vel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            if (vel.magnitude < maxSpeed)
            {
                rb.AddForce(moveDir * movespeed * Time.fixedDeltaTime);
            }

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactoredPerFrame * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (view.IsMine)
        {
            canJump = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (view.IsMine)
        {
            canJump = false;
        }
    }
    public void respawn(Vector3 respawnPos)
    {
        transform.position = respawnPos;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
