
using UnityEngine;
public class SpeedDebuff : TriggerObstacle
{
    public float EffectDuration { get => effectDuration; }

    private void Awake()
    {
        speedDrop = 25.0f;
        effectDuration = 10.0f; // Inicializamos effectDuration
    }

    public override void ApplyEffect(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        float playerSpeed = rb.velocity.magnitude;

        if (playerSpeed > speedDrop)
        {
            rb.velocity = rb.velocity.normalized * (playerSpeed - speedDrop);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with Fence");
            ApplyEffect(collision.gameObject);
        }
    }
}


