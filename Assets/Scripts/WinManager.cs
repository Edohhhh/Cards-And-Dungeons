using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField] Win win;
    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
        Destroy(gameObject);
    }

    public void Salir()
    {

        Debug.Log("Salir...");
        Application.Quit();
    }


}
