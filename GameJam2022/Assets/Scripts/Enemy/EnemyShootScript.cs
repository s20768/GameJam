using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    public Transform bulletHole;
    Transform player;
    public Animator animator;
    public GameObject bullet;
    private SpriteRenderer _sr;
    [SerializeField] private float cdr = 4f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.position, animator.transform.position);
        cdr -= Time.deltaTime;
        if (distance < 3f && cdr < 1f)
        {
            animator.SetTrigger(AnimatorValues.isShooting);
            Fire();
            cdr = 2f;
        }
        if (cdr <= 0f)
        {
            cdr = 2f;
        }
    }

    void Fire()
    {
        GameObject shoot = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
    }



}