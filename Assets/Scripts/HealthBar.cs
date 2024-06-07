using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    public int maxLife;
    public Transform startPosition;

    //Resetear la ecena
    private Scene currentScene;

    void Start()
    {
        startPosition = transform;
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {

        if (life <= 1)
        {
            Destroy(hearts[0].gameObject);
            Lose();
           
        }
        else if (life <= 10)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life <= 20)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (life <= 30)
        {
            Destroy(hearts[3].gameObject);
        }

    }
    

    public void TakeDamage(int damage)
    {
        life -= damage;
    }


    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
