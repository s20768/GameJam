using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1;
    [SerializeField] public int health = 2;

    

    public Transform _player;
    private Rigidbody2D _rb;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        _rb = GetComponent<Rigidbody2D>();
    }
    
   
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
