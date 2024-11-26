using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PoolableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            return;
        }
        ReturnHandler?.Invoke();
    }
}
