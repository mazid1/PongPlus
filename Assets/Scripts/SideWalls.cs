using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideWalls : MonoBehaviour {

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.name == "Ball") {
            GameManager.ScoreUpdate(transform.name);
            collider.gameObject.SendMessage("RestartGame");
        }
    }
}
