using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEspada : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Obtener la posici�n del mouse en coordenadas del mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calcular la direcci�n de la espada hacia la posici�n del mouse
            Vector3 direction = mousePosition - transform.position;
            direction.z = 0f; // Asegurarse de que la direcci�n sea en el plano XY

            // Calcular el �ngulo de rotaci�n basado en la direcci�n
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotar la espada hacia la direcci�n del mouse
            // Asumiendo que la espada est� anclada al jugador como un hijo (dependiendo de tu configuraci�n)
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
