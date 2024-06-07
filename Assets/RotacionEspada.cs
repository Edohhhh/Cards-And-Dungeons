using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEspada : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Obtener la posición del mouse en coordenadas del mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calcular la dirección de la espada hacia la posición del mouse
            Vector3 direction = mousePosition - transform.position;
            direction.z = 0f; // Asegurarse de que la dirección sea en el plano XY

            // Calcular el ángulo de rotación basado en la dirección
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotar la espada hacia la dirección del mouse
            // Asumiendo que la espada está anclada al jugador como un hijo (dependiendo de tu configuración)
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
