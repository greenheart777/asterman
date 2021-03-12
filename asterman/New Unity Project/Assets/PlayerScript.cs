using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rig; // it will be player component rigidbody
    public int jumpCount;
    public int jumoCountMax;
    public int jumpForce;

    void Awake()
    {
        rig = GetComponent<Rigidbody>(); // get rigidbody on "rig"
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (jumpCount < jumoCountMax)
        {
            //rig.AddForce(new Vector2(0, jumpForce), ForceMode.Acceleration);
            rig.velocity = Vector2.up * jumpForce;
            jumpCount++;            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            jumpCount = 0;
        }
    }
}
