using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : MonoBehaviour, ICollectible
{
    public static event Action OnCabbageCollected;
    public void Collect()
    {
        OnCabbageCollected?.Invoke();
        Destroy(gameObject);
    }
}

