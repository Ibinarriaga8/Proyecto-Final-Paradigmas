using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : PhysicalObstacle
{
    public float EffectDuration { get => effectDuration; }
    private void Awake()
    {
        effectDuration = 20.0f; // Inicializamos effectDuration
        obstacleDamage = 10; // Inicializamos obstacleDamage
    }
    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(obstacleDamage);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with Fence!");
            ApplyEffect(collision.gameObject);
        }
    }
}