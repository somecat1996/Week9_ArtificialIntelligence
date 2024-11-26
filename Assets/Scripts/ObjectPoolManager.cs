using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; }

    public GameObject bulletPrefab;

    public bool collectionChecks = true;
    public int maxPoolSize = 100;

    private ObjectPool<GameObject> pool;
    public ObjectPool<GameObject> Pool
    {
        get
        {
            if (pool == null)
            {
                pool = new ObjectPool<GameObject>(
                    OnCreatePoolObject,
                    OnGetFromPool,
                    OnReturnedToPool,
                    OnRemoveFromPool,
                    collectionChecks,
                    25,
                    maxPoolSize
                    );
            }

            return pool;
        }
    }

    private GameObject OnCreatePoolObject()
    {
        GameObject gameObject = Instantiate(bulletPrefab, transform);

        // TODO: give the object a reference to the pool
        gameObject.GetComponent<ReturnToPool>().Pool = pool;

        return gameObject;
    }

    private void OnGetFromPool(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void OnReturnedToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void OnRemoveFromPool(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
