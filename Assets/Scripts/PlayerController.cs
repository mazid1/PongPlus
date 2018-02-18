using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10f;

    private Rigidbody2D rBody;

    private void Start ()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKey(moveUp)) {
            rBody.velocity = new Vector2(0f, speed);
        }
        else if(Input.GetKey(moveDown)) {
            rBody.velocity = new Vector2(0f, -speed);
        }
        else {
            rBody.velocity = new Vector2(0f, 0f);
        }
	}
}
