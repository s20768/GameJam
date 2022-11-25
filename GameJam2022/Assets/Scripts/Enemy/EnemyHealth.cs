using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] GameObject pierog;
    [SerializeField] GameObject pierog2;
    [SerializeField] GameObject pierog3;

    public Transform _player;
    private Rigidbody2D _rb;

    private int _dmg;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        _rb = GetComponent<Rigidbody2D>();
        _dmg = 1;
    }

    private void Update()
    {
        SpawnPierog();

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "towel")
        {
            Destroy(collision.gameObject);
            TakeDmg(_dmg);
        }
    }

    private void TakeDmg(int dmg)
    {
        if (health > 0)
        {
            health -= dmg;
        }
    }

    private void SpawnPierog()
    {
        int rnd = Random.Range(1, 4);


        if (health <= 0)
        {
            switch (rnd)
            {
                case 1:
                    Instantiate(pierog, _rb.position, _rb.transform.rotation);
                    break;
                case 2:
                    Instantiate(pierog2, _rb.position, _rb.transform.rotation);
                    break;
                case 3:
                    Instantiate(pierog3, _rb.position, _rb.transform.rotation);
                    break;
            }
            Destroy(gameObject);

        }

    }


    private void OnCabbageCollected()
    {
        if (health <= 5)
        {
            _dmg = 2;
        }
    }

    private void OnEnable()
    {

        Cabbage.OnCabbageCollected += OnCabbageCollected;
    }

    private void OnDisable()
    {

        Cabbage.OnCabbageCollected += OnCabbageCollected;
    }
}
