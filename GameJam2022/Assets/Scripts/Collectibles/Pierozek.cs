using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pierozek : MonoBehaviour, ICollectible
{
    public static event Action OnPierozekCollected;
    public void Collect()
    {
        OnPierozekCollected?.Invoke();
        Destroy(gameObject);
    }
}
