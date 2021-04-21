using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public CircleCollider2D circleCollider;
    public Animator animator;
    [SerializeField] private LayerMask layerMask;

    public float speed = 40f;
    float horizontalMove = 0f;

    public GameObject firebaseManager;

    bool jump = false;
    bool isDead = false;
    bool isFinished = false;
    bool isPaused = false;

    Vector3 checkpoint;
    Transform playerTransform;

    public GameObject timerObj;
    public GameObject scoreObj;
    float timer;

    int scoreMultiplier = 10;
    int maxScore = 1000;

    public SceneLoader sceneLoader;
    public float deathBoundary;

    public UnityEvent OnDeath;
    public UnityEvent OnFinish;
    public UnityEvent OnPause;
    void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = StaticVars.playerColor;

        if (OnDeath == null)
            OnDeath = new UnityEvent();

        if (OnFinish == null)
            OnFinish = new UnityEvent();

        if (OnPause == null)
            OnPause = new UnityEvent();
    }
    void Start()
    {
        //Get Trasnform and updated checkpoint position
        playerTransform = GetComponent<Transform>();
        checkpoint = playerTransform.position;
        timer = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check collision with Obstacles
        if (collision.gameObject.name == "Obstacles")
        {
            isDead = true;
            //OnDeath.Invoke();
            Respawn();
        }

        //Check collision with Coin for winning/finish line
        if (collision.gameObject.name == "Coin")
        {
            horizontalMove = 0;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            collision.gameObject.SetActive(false);
            isFinished = true;

            Finish();
        }

        //Check collision with checkpoint
        if (collision.gameObject.name.Contains("Checkpoint"))
        {
            collision.gameObject.SetActive(false);
            checkpoint = collision.gameObject.transform.position;
        }
    }
    void Update()
    {
        //Check if player fell off the screen
        if (circleCollider.bounds.center.y < deathBoundary && !isDead)
        {
            isDead = true;
            //OnDeath.Invoke();
            Respawn();
        }

        if (!isDead)
        {

            if (!isFinished && !isPaused)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

                //Jump
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    animator.SetBool("isJumping", true);
                }

                //Pause
                if (Input.GetButtonDown("Pause"))
                {
                    isPaused = true;
                    Time.timeScale = 0;
                    OnPause.Invoke();
                }

                timer += Time.deltaTime;
                timerObj.GetComponent<TextMeshProUGUI>().text = ((Mathf.RoundToInt(timer * 100))/100.0f).ToString();
            }

            //Check if player is grounded to reset animation
            if (IsGrounded())
            {
                animator.SetBool("isJumping", false);
            }
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
        return raycastHit.collider != null;
    }
    void FixedUpdate()
    {
        //Move player
        if (!isDead)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
    void Respawn()
    {
        playerTransform.position = checkpoint;
        isDead = false;
    }
    //Unpause the game
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
    void Finish()
    {
        //Calculate final score
        float finalScore = (maxScore - (Mathf.Round(timer * 1000) / 1000f * scoreMultiplier));
        scoreObj.GetComponent<TextMeshProUGUI>().text = "Score = " + finalScore.ToString();
        
        firebaseManager.GetComponent<InGameDatabase>().SaveScore(finalScore);
        OnFinish.Invoke();
    }
}
