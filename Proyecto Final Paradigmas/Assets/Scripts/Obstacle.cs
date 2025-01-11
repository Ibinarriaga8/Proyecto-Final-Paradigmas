using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected float effectDuration;
    public abstract void ApplyEffect(GameObject player);
}

public abstract class PhysicalObstacle : Obstacle
{
    protected int obstacleDamage;
    public abstract void OnCollisionEnter(Collision collision);
}

public abstract class TriggerObstacle : Obstacle
{
    protected float speedDrop;
    public abstract void OnTriggerEnter(Collider other);
}
