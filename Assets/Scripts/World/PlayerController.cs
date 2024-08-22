using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public Animator animator;
    private bool isMoving = false;
    public Vector3 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        animator.SetFloat("Horizontal", moveHorizontal);
        animator.SetFloat("Vertical", moveVertical);

        bool currentMovingState = moveHorizontal != 0.0f || moveVertical != 0.0f;

        if (isMoving != currentMovingState)
        {
            isMoving = currentMovingState;
            animator.SetBool("isMoving", isMoving);
        }

        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    
}
