using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour

{
    [SerializeField] private float _speed = 2f;
    private Rigidbody2D _rb;
    private GameObject _player;


    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        Vector3 direction = _player.transform.position - transform.position;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * _speed;
        float rotation = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

   

    

    
}
