using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explosion;
    public float force = 500.0f;
    public float mass = 0.3f;
    private Rigidbody2D rb;
    private float cameraXLimit = 19.0f;
    private float cameraYLimit = 11.25f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.mass = mass;
        rb.velocity = PlayerMovement.rb.velocity;
        rb.AddRelativeForce(Vector3.up * force);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.name.StartsWith("Asteroid"))
            return;

        if (Math.Abs(transform.position.x) < cameraXLimit && Math.Abs(transform.position.y) < cameraYLimit)
        {
            GameObject explosionObject = Instantiate(explosion.gameObject);
            explosionObject.transform.position = collider.transform.position;
            ParticleSystem ps = explosionObject.GetComponent<ParticleSystem>();
            ps.transform.localScale = collider.transform.localScale;
            Destroy(explosionObject, 1.0f);
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }

    }
}
