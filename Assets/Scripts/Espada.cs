using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    [SerializeField] private float vida;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigos"))
        {
            other.GetComponent<Enemigos>().TomarDaño(vida);

        }
    }
}
