using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player elements
    private Rigidbody2D rb2D;
    private Animator anim;

    // Jump variables
    [Tooltip("Amount of force applied to jump")]
    public float jumpForce;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform groundCheck;
    float groundRadius = 0.01f;

    // Movement variables
    public float speed = 1.8f;
    private bool facingRight = true;

     void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 0.4f;
        anim.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentState == GameState.inGame)
            Movement();
        if (Input.GetButtonDown("Jump") && GameManager.sharedInstance.currentState == GameState.inGame) {
            Jump();
        }
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,groundLayer);
        anim.SetBool("isGrounded", isGrounded);

        

        anim.SetFloat("vSpeed", rb2D.velocity.y);

    }

    void Jump()
    {
        if (isGrounded)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    /* Unused due to bugs
    bool isOnGround() {
        if (Physics2D.Raycast(this.transform.position, -this.transform.up, 0.5f, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */
    void Movement() {
        float move = Input.GetAxis("Horizontal");

        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

        anim.SetFloat("Movement", Mathf.Abs(move));

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
