using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float delay = 0.5f;
    private bool invoking = false;
    void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            if (!invoking)
            {
                InvokeRepeating(nameof(shoot), 0, delay);
                invoking = true;
            }
        }
        else
        {
            CancelInvoke();
            invoking = false;
        }
    }
    void shoot()
    {
        Destroy(Instantiate(bulletPrefab, transform.position, transform.rotation).gameObject, 10);
    }
}
