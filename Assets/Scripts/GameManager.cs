using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Text text1;
    public Text text2;
    public GameObject ball;

    private int score1 = 0;
    private int score2 = 0;
    private int maxBalls = 3;
    private int currentBalls = 0;

    private void Awake ()
    {
        instance = this;
    }

    private void Start () {
        instance.StartCoroutine (instance.Spawn ());
    }

    public static void ScoreUpdate (string wallName) {
        instance.currentBalls--;
        if (instance.currentBalls == 0) {
            StartNewRound();
        }

        if (wallName == "rightWall") {
            instance.score1++;
            instance.text1.text = "" + instance.score1;
        }
        else {
            instance.score2++;
            instance.text2.text = "" + instance.score2;
        }
    }

    IEnumerator Spawn () {
        for (int i = 0; i < instance.maxBalls; i++) {
            Vector3 spawnPosition = Vector3.zero;
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            instance.currentBalls++;
            yield return new WaitForSeconds(3.0f);
        }
    }

    public static int GetMaxBalls () {
        return instance.maxBalls;
    }

    public static int GetCurrentBalls () {
        return instance.currentBalls;
    }

    public static void StartNewRound () {
        instance.StartCoroutine (instance.Spawn());
    }
}
