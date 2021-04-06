using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public SceneLoader sceneLoader;
    public float deathBoundary;
    public UnityEvent OnFallOffScreen;

    private void Awake()
    {
        if (OnFallOffScreen == null)
            OnFallOffScreen = new UnityEvent();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        
        //Check if player is grounded
        if (IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }

        //Check if player fell off the screen
        if (circleCollider.bounds.center.y < deathBoundary)
        {
            //sceneLoader.ReloadGame();
            OnFallOffScreen.Invoke();
        }
    }
    private bool IsGrounded()
    {
        float extraHeight = -0.01f;
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
        //Move player
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
