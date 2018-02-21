using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D mRigidbody2D;
    private Vector2 velocity;
    private int verticalForce = 10;
    private int horizontalForce = 30;
    //private float time = 0.0f;
    private float speedMultiplier = 1.0005f;
    private float maxVelocityY = 7.0f;
    private float maxVelocityX = 1.5f;
    private ContactPoint2D[] contactPoints;

    // Use this for initialization
    void Start () {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        velocity = new Vector2();
        contactPoints = new ContactPoint2D[10];
        Invoke("GoBall", 2);
	}

    private void GoBall () {
        float rand = Random.Range(0, 2);
        if (rand < 1) {
            rand = Random.Range(0, 2);
            if (rand < 1)
                mRigidbody2D.AddForce(new Vector2(horizontalForce, verticalForce));
            else
                mRigidbody2D.AddForce(new Vector2(-horizontalForce, verticalForce));
        } else {
            rand = Random.Range(0, 2);
            if (rand < 1)
                mRigidbody2D.AddForce(new Vector2(horizontalForce, -verticalForce));
            else
                mRigidbody2D.AddForce(new Vector2(-horizontalForce, -verticalForce));
        }
    }

    private void Update () {
        //time += Time.deltaTime;
        velocity.x = mRigidbody2D.velocity.x * speedMultiplier;
        velocity.y = mRigidbody2D.velocity.y;
        mRigidbody2D.velocity = velocity;
        //Debug.Log("velocity = " + velocity.x);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.GetContacts (contactPoints);

            if (mRigidbody2D.velocity.x > 0) {
                velocity.x =
                    mRigidbody2D.velocity.x
                    + (Mathf.Abs ((collision.transform.InverseTransformPoint (contactPoints[0].point)).y)
                    * maxVelocityX);
            } else {
                velocity.x = 
                    mRigidbody2D.velocity.x 
                    - (Mathf.Abs ((collision.transform.InverseTransformPoint (contactPoints[0].point)).y) 
                    * maxVelocityX);
            }

            if (velocity.x < 5.0f && velocity.x > -5.0f) {
                if (velocity.x > 0)
                    velocity.x = 5.0f;
                else
                    velocity.x = -5.0f;
            }

            velocity.y = (collision.transform.InverseTransformPoint (contactPoints[0].point)).y * maxVelocityY;
            mRigidbody2D.velocity = velocity;
        }
        else if (collision.collider.CompareTag("Ball")) {
            velocity = mRigidbody2D.velocity;
            if (velocity.x < 5.0f && velocity.x > -5.0f) {
                if (velocity.x > 0)
                    velocity.x = 5.0f;
                else
                    velocity.x = -5.0f;
            }
            mRigidbody2D.velocity = velocity;
        }
    }

    private void ResetBall () {
        mRigidbody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void RestartGame() {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
