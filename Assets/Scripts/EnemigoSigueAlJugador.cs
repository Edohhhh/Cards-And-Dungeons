using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemigoSigueAlJugador : MonoBehaviour
{
    public float speed;
    public bool perseguir = false;
    public Transform startingPoint;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        if (perseguir == true)
            Perseguir();
        else
            ReturnToStartingPosition();
        Flip();
    }
    private void Perseguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void ReturnToStartingPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = quaternion.Euler(0,100, 0);
    }

    public void Lento(float relentizar)
    {
        speed -= relentizar;
    }

}

