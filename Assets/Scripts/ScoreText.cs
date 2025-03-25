using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreText : MonoBehaviour
{

    public TextMeshProUGUI MyScoreText;
    public TextMeshProUGUI damageText;

    public GameObject ReStartPanel;

    public GameObject player;

    public GameObject Enemy;

    private int ScoreNum;
    private int DamageNum;

    private bool levelCompleteLogged = false; // Flag to track if the log has been printed

    void Start()
    {
        ScoreNum = 0;
        DamageNum = 0;

        // Initialize the texts
        MyScoreText.text = "" + ScoreNum;
        damageText.text = "" + DamageNum;
    }

    public void AddScore(int scoreToAdd)
    {
        // Increment score
        ScoreNum += scoreToAdd;
        MyScoreText.text = "" + ScoreNum;

        // Increment damage by 100 for each score increment
        DamageNum += 100;
        damageText.text = "" + DamageNum;

        // // Check if ScoreNum is 10 and log level complete only once
        // if (ScoreNum == 10 && !levelCompleteLogged)
        // {
        //     Debug.Log("Level Complete!");
        //     GameOver();
        //     levelCompleteLogged = true; // Set the flag to true to prevent future logs
        // }
    }

        public void GameOver()
    {
        Debug.Log("Game Over!");
        ReStartPanel.SetActive(true);
        if (player != null)
        {
            player.SetActive(false);
        }

       
}
} 
