using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_mover : MonoBehaviour
{

    public float movespeed;
    public float k;

    private Rigidbody rb1;
    void Start()
    {
        rb1 = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {


        if(Input.GetKey(KeyCode.A))
        {
            if(Mathf.Abs(rb1.velocity.x) < movespeed * k)
            {
                rb1.velocity -= new Vector3(movespeed, 0f, 0f);
            }
            

        }
        else
        if (Input.GetKey(KeyCode.D))
        {
            if (Mathf.Abs(rb1.velocity.x) < movespeed * k)
            {
                rb1.velocity += new Vector3(movespeed, 0f, 0f);
            }

        }



        if(Input.GetKey(KeyCode.W))
        {
            if (Mathf.Abs(rb1.velocity.y) < movespeed * k)
            {
                rb1.velocity += new Vector3(0f, movespeed, 0f);
            }
                

        }
        else
        if(Input.GetKey(KeyCode.S))
        {
            if (Mathf.Abs(rb1.velocity.y) < movespeed * k)
            {
                rb1.velocity -= new Vector3(0f, movespeed, 0f);
            }
        }



        if (Input.GetKey(KeyCode.Q))
        {
            if(Mathf.Abs(rb1.velocity.z) < movespeed *k)
            {
                rb1.velocity += new Vector3(0f, 0f, movespeed);
            }
            

        }
        else
        if (Input.GetKey(KeyCode.E))
        {
            if (Mathf.Abs(rb1.velocity.z) < movespeed * k)
            {
                rb1.velocity -= new Vector3(0f, 0f, movespeed);
            }

        }


        if(!Input.anyKey)
        {
            rb1.velocity = new Vector3(0f, 0f, 0f);
        }

    }
}
