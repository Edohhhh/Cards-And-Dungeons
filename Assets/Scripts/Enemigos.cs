using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] private float vida; 
    [SerializeField] private float MaxVida;

    private Animator animator;


    void Start()
    {
        vida = MaxVida;
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float Daño)
    {
        vida -= Daño;
        if (vida <= 0)
        {
            Muerte();
            
        }
    }

    private void Muerte()
    {


        Destroy(gameObject);
        //animator.SetTrigger("Muerte");

    }


}
