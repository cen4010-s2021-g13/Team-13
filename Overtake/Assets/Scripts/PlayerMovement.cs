using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    //public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;
    public Animator animator;
    [SerializeField] private LayerMask layerMask;

    public float speed = 40f;
    float horizontalMove = 0f;

    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }
    }
    private bool IsGrounded()
    {
        float extraHeight = 0.01f;
        RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.down, circleCollider.radius + extraHeight, layerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(circleCollider.bounds.center, Vector2.down * (circleCollider.radius + extraHeight));
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
