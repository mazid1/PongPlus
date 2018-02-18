using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private static int score1 = 0;
    private static int score2 = 0;
    public Text text1;
    public Text text2;

    private void Awake ()
    {
        instance = this;
    }

    public static void ScoreUpdate (string wallName) {
        if (wallName == "rightWall") {
            score1++;
            instance.text1.text = "" + score1;
        }
        else {
            score2++;
            instance.text2.text = "" + score2;
        }
    }
}
