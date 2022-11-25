using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    
    Vector2 movment;
    Vector2 mousePos;

    void Update()
    {

        rb = GetComponent<Rigidbody2D>();

        movment.x = Input.GetAxisRaw(Axis.HORIZONTAL);
        movment.y = Input.GetAxisRaw(Axis.VERTICAL);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

      
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        Vector2 aimDirection = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

    }

    private void OnPierozekCollected()
    {
        moveSpeed = 5f;
        StartCoroutine(Hide());
    }



    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(3);
        moveSpeed = 5f;
    }

    


    private void OnEnable()
    {
        Pierozek.OnPierozekCollected += OnPierozekCollected;
    }

    private void OnDisable()
    {
        Pierozek.OnPierozekCollected -= OnPierozekCollected;
    }
}
