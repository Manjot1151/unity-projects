using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    public bool isGrounded = true;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
        speed = 6f;
        jumpForce = 6f;
        rb.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -4.9f)
        {
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }
        Move();
        Jump();
        FastFall();
    }

    void Move()
    {   
        float direction = Input.GetAxis("Horizontal");
        float x = direction * speed;
        rb.velocity = new Vector2(x, rb.velocity.y);
        
        if (sr.flipX && direction == -1)
        sr.flipX = false;

        else if (!sr.flipX && direction == 1)
        sr.flipX = true;
        
    }
    void Jump()
    {
        if (isGrounded && Input.GetAxisRaw("Vertical") == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
        

    }
    void FastFall()
    {
        rb.gravityScale = Input.GetAxisRaw("Vertical")==-1? 5: 1;
    }
}
