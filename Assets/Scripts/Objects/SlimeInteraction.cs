using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeInteraction : MonoBehaviour
{
    [Range(0, 1)]
    public float slowdownAmount;
    Rigidbody2D ballRb;
    bool slowdownEnable = false;

    void FixedUpdate()
    {
        if (slowdownEnable == true) { Slowdown(ballRb); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball") { slowdownEnable = true; }
        ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball") { slowdownEnable = false; }
        ballRb = null;
    }

    void Slowdown(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x * slowdownAmount, rb.velocity.y * slowdownAmount);
    }
}
