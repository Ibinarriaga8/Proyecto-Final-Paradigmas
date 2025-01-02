using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Rigidbody playerRB;
    public Vector3 Offset; // Offset of the camera from the player
    public float speed; // Speed of the camera following the player
    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerForward = (playerRB.velocity + player.transform.forward).normalized; // Get the forward direction of the player
        transform.position = Vector3.Lerp(transform.position, player.position + player.transform.TransformVector(Offset) + playerForward * (-7f), speed * Time.deltaTime);
        transform.LookAt(player); //Camera always looks at the player

    }
}
