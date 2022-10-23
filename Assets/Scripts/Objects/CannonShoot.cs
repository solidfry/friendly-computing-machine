using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public Transform cannonBarrel, barrelTip;
    public float explosionForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            MoveBallToCannonBarrel(collision.gameObject);

            FireBall(collision.gameObject.GetComponent<Rigidbody2D>(), barrelTip);
        }
    }

    Vector2 CalculateForceDirection(Transform tipTransform)
    {
        return (tipTransform.position - cannonBarrel.position).normalized;
    }

    void MoveBallToCannonBarrel(GameObject ball) 
    {
        ball.transform.position = barrelTip.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void FireBall(Rigidbody2D rb, Transform tipTransform) => rb.AddForce(CalculateForceDirection(tipTransform) * explosionForce, ForceMode2D.Impulse);
}
