using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Prefab del cuadrado a invocar
    public GameObject squarePrefab;

    // M�todo que se invoca cuando se usa la carta
    public void OnCardUsed()
    {
        // Invocar un cuadrado en la escena
        SpawnSquare();
    }

    // M�todo que invoca un cuadrado
    private void SpawnSquare()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane; // Ajustar seg�n la profundidad requerida
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Instantiate(squarePrefab, worldPosition, Quaternion.identity);
    }
}

