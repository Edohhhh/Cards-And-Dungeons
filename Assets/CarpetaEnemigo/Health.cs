using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10;

    [SerializeField] private GameObject bloodParticle;

    [SerializeField] private Renderer renderer;
    [SerializeField] private float flashTime = 0.2f;

    private void Start()
    {

    }

}

