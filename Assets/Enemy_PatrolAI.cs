using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PatrolAI : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float tiempoEspera;

    private int puntoActual;
    private bool esperando;
    private Transform[] puntosPatrulla;
    private MonoBehaviour controladorCoroutine;

    // OnStateEnter se llama cuando una transición comienza y la máquina de estados empieza a evaluar este estado
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        puntoActual = 0;
        esperando = false;
        controladorCoroutine = animator.GetComponent<MonoBehaviour>();

        // Buscar los waypoints del controlador
        PatrolController patrolController = animator.GetComponent<PatrolController>();
        if (patrolController != null)
        {
            puntosPatrulla = patrolController.waypoints;
        }

        // Asegurarse de que los puntos de patrulla estén asignados
        if (puntosPatrulla == null || puntosPatrulla.Length == 0)
        {
            Debug.LogError("Puntos de patrulla no asignados para el comportamiento de patrulla");
            return;
        }
    }

    // OnStateUpdate se llama en cada frame de actualización entre OnStateEnter y OnStateExit
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!esperando && animator.transform.position != puntosPatrulla[puntoActual].position)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, puntosPatrulla[puntoActual].position, velocidadMovimiento * Time.deltaTime);
        }
        else if (!esperando)
        {
            controladorCoroutine.StartCoroutine(Esperar());
        }
    }

    private IEnumerator Esperar()
    {
        esperando = true;
        yield return new WaitForSeconds(tiempoEspera);
        puntoActual++;

        if (puntoActual == puntosPatrulla.Length)
        {
            puntoActual = 0;
        }
        esperando = false;

        Girar();
    }

    private void Girar()
    {
        if (controladorCoroutine.transform.position.x > puntosPatrulla[puntoActual].position.x)
        {
            controladorCoroutine.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            controladorCoroutine.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}