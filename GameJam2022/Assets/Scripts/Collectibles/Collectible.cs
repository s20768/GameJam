using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    private GameObject gm;


    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            OnCollected?.Invoke();
        }
    }

}
