using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPooler : MonoBehaviour
{
    #region Fields
    private GameObject _CollapsePollerGO; // Reference to the pooler's GameObject
    private List<GameObject> _PooledObject = new List<GameObject>(); // List to store pooled objects
    [SerializeField] private GameObject _ObjectToPool; // GameObject to pool
    [SerializeField] private int _AmountToPool; // Number of objects to initially pool
    #endregion

    void Start()
    {
        _CollapsePollerGO = this.gameObject; // Set the pooler's GameObject reference
        Save(); // Initialize the object pool
    }

    // Method to initialize the object pool
    public void Save()
    {
        // Check if the object to pool is null
        if (_ObjectToPool == null) return;

        GameObject go;
        // Loop to instantiate and add objects to the pool
        for (int i = 0; i < _AmountToPool; i++)
        {
            go = Instantiate(_ObjectToPool); // Instantiate the object
            go.transform.parent = _CollapsePollerGO.transform; // Set the pooler as parent
            go.SetActive(false); // Set the object to inactive
            _PooledObject.Add(go); // Add the object to the pool
        }
    }

    // Method to retrieve an object from the pool
    public GameObject OnTakeFromPool()
    {
        // Loop through the pooled objects
        for (int i = 0; i < _PooledObject.Count; i++)
        {
            // Check if the object is not active in the hierarchy
            if (!_PooledObject[i].activeInHierarchy)
            {
                GameObject go = _PooledObject[i]; // Get the object
                go.SetActive(true); // Set the object to active
                return go; // Return the object
            }
        }

        return null; // Return null if no inactive object found
    }

    // Method to retrieve and position an object from the pool
    public GameObject OnTakeFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject go = OnTakeFromPool(); // Retrieve an object from the pool
        if (go)
        {
            go.transform.position = position; // Set the object's position
            go.transform.rotation = rotation; // Set the object's rotation

            return go; // Return the object
        }

        return null; // Return null if no object retrieved
    }

    // Method to return an object to the pool after a delay
    public async UniTask OnReturnToPool(GameObject go, float delayTimeInSecond = 0)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(delayTimeInSecond)); // Delay for the specified time

        go.transform.parent = _CollapsePollerGO.transform; // Set the pooler as parent
        go.SetActive(false); // Set the object to inactive
    }
}
