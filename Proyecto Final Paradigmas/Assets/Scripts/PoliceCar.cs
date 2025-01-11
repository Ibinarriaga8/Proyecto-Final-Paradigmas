using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PoliceCar : PhysicalObstacle
{
    private NavMeshAgent agent;
    private Transform player;
    
    // Start is called before the first frame update
    void Awake()
    {
        obstacleDamage = 50;
        //Asignamos las variables
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<RaceCar>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position; //cada frame buscamos la posici�n del jugador

    }

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(obstacleDamage);
        Debug.Log("ME HAN CHOCADO");
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyEffect(collision.gameObject);
        }
    }
}
