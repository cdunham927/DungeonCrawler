using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float spd;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward, spd * Time.deltaTime);
    }
    
    private void OnTriggerExit(Collider collision)
    {
        collision.transform.position = transform.position;
    }
}
