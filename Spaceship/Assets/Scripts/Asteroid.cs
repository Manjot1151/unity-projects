using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size;
    public float minSize;
    public float maxSize;
    public float force;
    public float maxLife;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    void Awake()
    {
        size = 0f;
        minSize = 3.0f;
        maxSize = 10.0f;
        force = 50.0f;
        maxLife = 50.0f;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.value * 360);
        rb.mass = size;
        sr.size = new Vector2(size, size);
    }
    public void Throw(Vector2 direction)
    {
        transform.localScale = Vector3.one * size;
        rb.AddForce(direction * force);
        Destroy(this.gameObject, maxLife);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Rocket"))
        {
            GameLoop.alive = false;
        };
    }
}