using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer mySprite;
    private bool GameStarted;
    public float JumpThrust = 300f;
    public float ForwardThrust = 2f;
    public static bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            if (isDead)
            {
                SceneManager.LoadScene("SampleScene");
                Bird.isDead = false;
            }
            else
            {
                Jump();
                rb.gravityScale = 1;
                GameStarted = true;
            }
        }
        if (GameStarted && !isDead)
        {
            rb.velocity = new Vector2(ForwardThrust, rb.velocity.y);
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan(rb.velocity.y/rb.velocity.x)*180/Mathf.PI),  Time.deltaTime*2);
            ScoreUpdate.score = (int)(rb.transform.position.x / 5);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.name.StartsWith("sky"))
            Die();
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * JumpThrust);
        SoundManagerScript.PlayJumpSound();
    }
    private void Die()
    {
        rb.GetComponent<CircleCollider2D>().isTrigger = true;
        rb.velocity = Vector2.up * 3;
        rb.SetRotation(0);
        mySprite.color = Color.red;
        mySprite.flipY = true;
        isDead = true;
        GetComponent<Animator>().enabled = false;
        SoundManagerScript.PlayDeathSound();
    }
}
