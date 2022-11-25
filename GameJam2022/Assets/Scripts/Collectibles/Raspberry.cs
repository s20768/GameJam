using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raspberry : MonoBehaviour, ICollectible
{
    public static event Action OnRaspberryCollected;
    public void Collect()
    {
        OnRaspberryCollected?.Invoke();
        Destroy(gameObject);
    }
}
