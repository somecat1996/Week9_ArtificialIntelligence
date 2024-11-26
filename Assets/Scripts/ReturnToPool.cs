using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(PoolableObject))]
public class ReturnToPool : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    private void Awake()
    {
        GetComponent<PoolableObject>().ReturnHandler = OnReturnedToPool;
    }

    private void OnReturnedToPool()
    {
        Pool.Release(gameObject);
    }
}
