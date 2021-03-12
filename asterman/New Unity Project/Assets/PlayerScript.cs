using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rig; // it will be player component rigidbody
    public int jumpCount;
    public int jumoCountMax;
    public int jumpForce;

    public GameObject[] waypoints;
    public GameObject player;
    int current = 0;
    public float speed;
    float WPradius = 1;

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

        // Movement waypoints 
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }

    // Jump player
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
