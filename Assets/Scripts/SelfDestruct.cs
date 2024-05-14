using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timeTillDestruct = 20.0f; // Time in seconds until the object self-destructs

    void Start()
    {
        // Destroy the GameObject after the specified time
        Destroy(this.gameObject, timeTillDestruct);
    }
}
