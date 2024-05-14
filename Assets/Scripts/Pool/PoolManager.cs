using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Singleton instance of the PoolManager
    public static PoolManager Instance { get; private set; }

    // ObjectPooler for ObstacleA
    public ObjectPooler ObstacleA_pooler;

    // ObjectPooler for ObstacleB
    public ObjectPooler ObstacleB_pooler;

    private void Awake()
    {
        // Set the instance to this object
        Instance = this;
    }
}
