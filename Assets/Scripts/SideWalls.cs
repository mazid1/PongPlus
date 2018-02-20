using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideWalls : MonoBehaviour {

    //int ballsRemaining = 3;

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Ball") {
            //ballsRemaining--;
            GameManager.ScoreUpdate(transform.name);
            /*if (GameManager.GetCurrentBalls() == 0) {
                collider.gameObject.SendMessage("RestartGame");
            }*/
            /*if(ballsRemaining == 0) {
                collider.gameObject.SendMessage("RestartGame");
                ballsRemaining = 3; 
            }*/
        }
    }
}
