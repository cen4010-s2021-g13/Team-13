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
    bool isDead = false;
    bool isFinished = false;

    public SceneLoader sceneLoader;
    public float deathBoundary;
    public UnityEvent OnDeath;
    public UnityEvent OnFinish;

    private void Awake()
    {
        if (OnDeath == null)
            OnDeath = new UnityEvent();

        if (OnFinish == null)
            OnFinish = new UnityEvent();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check collision with Obstacles
        if (collision.gameObject.name == "Obstacles")
        {
            isDead = true;
            OnDeath.Invoke();
        }

        //Check collision with Coin for winning/finish line
        if (collision.gameObject.name == "Coin")
        {
            horizontalMove = 0;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            collision.gameObject.SetActive(false);
            isFinished = true;
            OnFinish.Invoke();
        }
    }
    void Update()
    {
        //Check if player fell off the screen
        if (circleCollider.bounds.center.y < deathBoundary)
        {
            isDead = true;
            OnDeath.Invoke();
        }

        if (!isDead && !isFinished)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }

        //Check if player is grounded to reset animation
        if (IsGrounded())
        {
            animator.SetBool("isJumping", false);
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
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
    void FixedUpdate()
    {
        //Move player
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
