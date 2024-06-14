using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public int layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) Destroy(collision.gameObject);
    }
}

