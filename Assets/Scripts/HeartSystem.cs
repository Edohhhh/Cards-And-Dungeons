using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{

    public Sprite[] heartSprites; // Array de sprites para los corazones en diferentes estados
    public GameObject[] hearts;   // Array de GameObjects que representan los corazones en la escena
    public int life;              // Vida del jugador
    public bool[] heartDamaged;   // Array de booleanos que indica si un coraz�n ha sido da�ado
    public bool dead;             // Variable que indica si el jugador est� muerto

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
                // Obtener el componente Animator del coraz�n
                Animator animator = hearts[i].GetComponent<Animator>();
                if (animator != null)
                {
                    // Si el coraz�n ha sido da�ado y tiene una animaci�n llamada "Damage", reproducir la animaci�n
                    if (heartDamaged[i] && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    {
                        animator.SetTrigger("Damage");
                        heartDamaged[i] = false; // Restablecer el estado del coraz�n
                    }
                }

                // Obtener el componente SpriteRenderer del coraz�n
                SpriteRenderer renderer = hearts[i].GetComponent<SpriteRenderer>();
                if (renderer != null && heartSprites.Length > i)
                {
                    // Cambiar el sprite del coraz�n seg�n el estado actual
                    renderer.sprite = heartSprites[i];
                }
            }
        }

        // Verificar si el jugador est� muerto
        if (dead)
        {
            Debug.Log("�Te has muerto!");
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        // Calcular el �ndice del coraz�n afectado
        int heartIndex = Mathf.Clamp(life / 5, 0, hearts.Length - 1);

        // Marcar el coraz�n como da�ado
        heartDamaged[heartIndex] = true;

        // Si el jugador ha perdido toda su vida
        if (life <= 0)
        {
            dead = true;
        }
    }
}
