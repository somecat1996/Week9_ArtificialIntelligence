using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    public delegate void ReturnedToPool();
    public ReturnedToPool ReturnHandler;
}
