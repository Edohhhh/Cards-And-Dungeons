using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float vida;

    public void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigos"))
        {
            other.GetComponent<Enemigos>().TomarDaño(vida);

        }
    }
}
