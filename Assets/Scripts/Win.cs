using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public static Win instance;
    public int enemigosEliminados = 0;
    public int cantidadParaVictoria = 2;

    void Awake()
    {
        // Asegurarse de que solo haya una instancia de GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemigoEliminado()
    {
        enemigosEliminados++;
        if (enemigosEliminados >= cantidadParaVictoria)
        {
            CambiarAPantallaDeVictoria();
        }
    }

    void CambiarAPantallaDeVictoria()
    {
        SceneManager.LoadScene("Win");
    }
}
