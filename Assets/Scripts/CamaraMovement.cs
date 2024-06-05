using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        
        if (transform.position != target.position)
        {
            Vector3 targetPosition =  new Vector3 (target.position.x, target.position.y, target.position.z);
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing);

        }
    }
}
