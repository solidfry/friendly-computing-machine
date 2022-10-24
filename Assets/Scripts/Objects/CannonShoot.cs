using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class CannonShoot : MonoBehaviour
{
    public Transform cannonBarrel, barrelTip;
    public FloatValue explosionForce;
    public FloatValue barrelAngle;

    private void Update()
    {
        RotateBarrel();
    }

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

    void FireBall(Rigidbody2D rb, Transform tipTransform) => rb.AddForce(CalculateForceDirection(tipTransform) * explosionForce.Value, ForceMode2D.Impulse);

    void RotateBarrel()
    {
        cannonBarrel.rotation = Quaternion.Euler(0f, 0f, barrelAngle.Value);
    }
}
