using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class Disparo : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

    public float tiempoDisparo = 0.5f;
    private float disparoNex = 1.5f;


    private void Update() {

        if (Input.GetKey("up") && Time.time > disparoNex)
        {
            Disparar();
            disparoNex = Time.time + tiempoDisparo;

        }
        else if (Input.GetKey("down") && Time.time > disparoNex)
        {
            disparoNex = Time.time + tiempoDisparo;
            Disparar2();

        }
        else if (Input.GetKey("left") && Time.time > disparoNex)
        {
            disparoNex = Time.time + tiempoDisparo;
            DispararIzquierda();
        }
        else if (Input.GetKey("right") && Time.time > disparoNex)
        {
            disparoNex = Time.time + tiempoDisparo;
            DispararDerecha();
        }
    }

    private void Disparar()
    {

    Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }

    private void Disparar2()
    {
        Quaternion rotacionInvertida = controladorDisparo.rotation * Quaternion.Euler(0, 0, 180f);

        Instantiate(bala, controladorDisparo.position, rotacionInvertida);
    }

    private void DispararIzquierda()
    {
        Quaternion rotacionIzquierda = controladorDisparo.rotation * Quaternion.Euler(0, 0, 90f);

        Instantiate(bala, controladorDisparo.position, rotacionIzquierda);
    }

    private void DispararDerecha()
    {
        Quaternion rotacionDerecha = controladorDisparo.rotation * Quaternion.Euler(0, 0, -90f);

        Instantiate(bala, controladorDisparo.position, rotacionDerecha);
    }


}
