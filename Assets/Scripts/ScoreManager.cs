using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text playerScoreText;

    private static int playerScore;
    private static ScoreManager Instance = null;

    void Start()
    {
        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy(gameObject); }
        SetPlayerScore(0);
    }

    public static void SetPlayerScore(int score)
    {
        playerScore = score;
        Instance.playerScoreText.text = playerScore.ToString();
    }

    public static int GetScore()
    {
        return playerScore;
    }



    public static void IncrementPlayerScore()
    {
        playerScore++;
        Instance.playerScoreText.text = playerScore.ToString();
    }

}
