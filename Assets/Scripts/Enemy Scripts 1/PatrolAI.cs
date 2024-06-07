using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoints;
    private bool isWaiting;
    void Update()
    {
        if(transform.position != waypoints[currentWaypoints].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoints].position, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Wait());
        }
    }


    IEnumerator Wait()
    { 
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoints++;

        if(currentWaypoints == waypoints.Length)
        {
            currentWaypoints = 0;
        }
        isWaiting = false;

        Flip();
    }

    private void Flip()
    {
        if(transform.position.x > waypoints[currentWaypoints].position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }

    }
     
}
