using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private Transform destination1;
    [SerializeField] private Transform destinationPrincipal;
    [SerializeField] private Transform destinationActual;


    public Transform GetDestination() {

        if (destinationActual == destinationPrincipal)
        {

            Transform[] destinations = { destination, destination1 };
            int randomIndex = UnityEngine.Random.Range(0, destinations.Length);

            return destinations[randomIndex];
        }
          else if (destinationActual == destination || destination1)
        {
            return destinationPrincipal;
        }


        return destinationPrincipal;

    }
}
