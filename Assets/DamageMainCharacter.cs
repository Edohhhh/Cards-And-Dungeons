using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMainCharacter : MonoBehaviour
{
    public int vida;
    [SerializeField] private float tiempoEntreDa�o;
    private float tiempoSiguienteDa�o;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {

            tiempoSiguienteDa�o -= Time.deltaTime;
            if (tiempoSiguienteDa�o <+ 0)
            { 
                other.GetComponent<HealthBar>().TakeDamage(vida);
                tiempoSiguienteDa�o = tiempoEntreDa�o;
            }
        }

    }

}