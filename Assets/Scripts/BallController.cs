using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D mRigidbody2D;
    private Vector2 velocity;
    private int verticalForce = 10;
    private int horizontalForce = 80;

	// Use this for initialization
	void Start () {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        velocity = new Vector2();
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

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            velocity.x = mRigidbody2D.velocity.x;
            velocity.y = (mRigidbody2D.velocity.y / 2.0f) + (collision.collider.attachedRigidbody.velocity.y / 3.0f);
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
