using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float spd;
    public float jumpSpd;
    Rigidbody bod;
    public float rotSpdX;
    public float rotSpdY;

    private void Awake()
    {
        bod = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float check = Input.GetAxis("Mouse X");
        //Debug.Log("Our x is " + check);
        float translation = Input.GetAxis("Mouse Y") * rotSpdY;
        float rotation = Input.GetAxis("Mouse X") * rotSpdX;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;


        transform.Rotate(0, rotation, 0);

        if (Cursor.lockState == CursorLockMode.None) Cursor.lockState = CursorLockMode.Confined;
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement.x != 0)
        {
            //Check for enemy encounter chance

            bod.AddForce(transform.right * spd * Time.fixedDeltaTime * movement.x);
        }
        if (movement.y != 0)
        {
            //Check for enemy encounter chance

            bod.AddForce(transform.forward * spd * Time.fixedDeltaTime * movement.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bod.AddForce(transform.up * jumpSpd);
        }
    }
}
