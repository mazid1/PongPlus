using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10f;

    private Camera cam;

    private Rigidbody2D mRigidbody2D;
    private Renderer mRenderer;
    private float maxHeight;

    private void Start ()
    {
        if (cam == null) {
            cam = Camera.main;
        }
        mRigidbody2D = GetComponent<Rigidbody2D> ();
        mRenderer = GetComponent<Renderer> ();
        Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
        Vector3 targetHeight = cam.ScreenToWorldPoint (upperCorner);
        float paddleHeight = mRenderer.bounds.extents.y;
        maxHeight = targetHeight.y - paddleHeight;
    }

    // FixedUpdate is called once per physics timestep
    void FixedUpdate () {
		if (Input.GetKey(moveUp)) {
            mRigidbody2D.velocity = new Vector2 (0f, speed);
        }
        else if(Input.GetKey(moveDown)) {
            mRigidbody2D.velocity = new Vector2 (0f, -speed);
        }
        else {
            mRigidbody2D.velocity = new Vector2 (0f, 0f);
        }
        Vector3 targetPosition = mRigidbody2D.transform.position;
        float targetHeight = Mathf.Clamp (targetPosition.y, -maxHeight, maxHeight);
        targetPosition = new Vector3 (targetPosition.x, targetHeight, targetPosition.z);
        mRigidbody2D.transform.position = targetPosition;
    }
}
