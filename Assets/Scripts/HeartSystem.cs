using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{

    public Sprite[] heartSprites; // Array de sprites para los corazones en diferentes estados
    public GameObject[] hearts;   // Array de GameObjects que representan los corazones en la escena
    public int life;              // Vida del jugador
    public bool[] heartDamaged;   // Array de booleanos que indica si un corazón ha sido dañado
    public bool dead;             // Variable que indica si el jugador está muerto

    void Start()
    {
        heartDamaged = new bool[hearts.Length];
    }

    void Update()
    {
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                // Obtener el componente Animator del corazón
                Animator animator = hearts[i].GetComponent<Animator>();
                if (animator != null)
                {
                    // Si el corazón ha sido dañado y tiene una animación llamada "Damage", reproducir la animación
                    if (heartDamaged[i] && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    {
                        animator.SetTrigger("Damage");
                        heartDamaged[i] = false; // Restablecer el estado del corazón
                    }
                }

                // Obtener el componente SpriteRenderer del corazón
                SpriteRenderer renderer = hearts[i].GetComponent<SpriteRenderer>();
                if (renderer != null && heartSprites.Length > i)
                {
                    // Cambiar el sprite del corazón según el estado actual
                    renderer.sprite = heartSprites[i];
                }
            }
        }

        // Verificar si el jugador está muerto
        if (dead)
        {
            Debug.Log("¡Te has muerto!");
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        // Calcular el índice del corazón afectado
        int heartIndex = Mathf.Clamp(life / 5, 0, hearts.Length - 1);

        // Marcar el corazón como dañado
        heartDamaged[heartIndex] = true;

        // Si el jugador ha perdido toda su vida
        if (life <= 0)
        {
            dead = true;
        }
    }
}
