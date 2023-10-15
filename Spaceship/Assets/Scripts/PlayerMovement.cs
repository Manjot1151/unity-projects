using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static Rigidbody2D rb;
    ParticleSystem ps;
    public float rotationSpeed;
    public float thrust;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        rotationSpeed = 200f;
        thrust = 0.2f;
        rb.freezeRotation = true;
    }
    void FixedUpdate()
    {
        transform.Rotate(Input.GetAxisRaw("Horizontal") * Vector3.back * rotationSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            ps.Play();
        }
    }
}
