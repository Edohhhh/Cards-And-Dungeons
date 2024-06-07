using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMainCharacter : MonoBehaviour
{
    public int vida;
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {

            tiempoSiguienteDaño -= Time.deltaTime;
            if (tiempoSiguienteDaño <+ 0)
            { 
                other.GetComponent<HealthBar>().TakeDamage(vida);
                tiempoSiguienteDaño = tiempoEntreDaño;
            }
        }

    }

}