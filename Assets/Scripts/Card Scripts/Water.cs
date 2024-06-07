using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    [SerializeField] private float relentizar;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigos"))
        {
            other.GetComponent<EnemigoSigueAlJugador>().Lento(relentizar);
        }
    }
}

