using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDePersecucion : MonoBehaviour
{
    public EnemigoSigueAlJugador[] enemyArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MainCharacter"))
        {
            foreach (EnemigoSigueAlJugador enemy in enemyArray)
            {
                enemy.perseguir = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MainCharacter"))
        {
            foreach (EnemigoSigueAlJugador enemy in enemyArray)
            {
                enemy.perseguir = false;
            }
        }
    }
}
