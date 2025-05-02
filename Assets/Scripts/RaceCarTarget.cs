using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action onTargetReached;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I hit an object");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has reached the target");
            onTargetReached?.Invoke();

        }
    }
}
