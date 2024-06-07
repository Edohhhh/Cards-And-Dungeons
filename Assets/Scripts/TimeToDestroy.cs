using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
    
    [SerializeField] private float timeToDestroy = 5f;

    void Start()
    {

        Destroy(gameObject, timeToDestroy);
    }
}

