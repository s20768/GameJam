using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class PlayerShoot : MonoBehaviour
{
    public Transform towelPoint;
    public GameObject towelPrefab;
    public GameObject towel;
    public Camera cam;
    public Animator animator;
    [SerializeField] private float towelSpeed = 10f;

    void Shoot()
    {
        
        
        Rigidbody2D rb = towel.GetComponent<Rigidbody2D>();
        rb.AddForce(towelPoint.up * towelSpeed, ForceMode2D.Impulse);
    }

    public void Attack()
    {
        animator.SetTrigger(AnimatorValues.Attack);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown(Axis.FIRE2))
        {
            
            StartCoroutine(Hide());
            Shoot();
        }

        if (Input.GetButtonDown(Axis.FIRE1))
        {
            Attack();
        }

        


    }

    private IEnumerator Hide()
    {
        towel = Instantiate(towelPrefab, towelPoint.position, towelPoint.rotation);
        yield return new WaitForSeconds(3);
        Destroy(towel);

    }


}