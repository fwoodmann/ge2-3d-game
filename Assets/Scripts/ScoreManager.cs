using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int highScore = 0;
    public int score = 0;

    public void Awake()
    {
        instance = this;
        highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name);
        ResetScore();
    }

    public void AddScore(int points)
    {
        score = score + points;
        //UpdateHighScore();
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("RunScore" + SceneManager.GetActiveScene().name ,score);
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }

        highScoreText.text = highScore.ToString();
        PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name,highScore);
    }

    public void ResetScore()
    {
        Debug.Log("Reset");
        score = 0;
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        PlayerPrefs.DeleteKey("RunScore" + SceneManager.GetActiveScene().name);
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore" + SceneManager.GetActiveScene().name);
    }
}