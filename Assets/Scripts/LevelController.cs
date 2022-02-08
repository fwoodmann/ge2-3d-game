using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI;
    public GameObject inGameUI;
    public Text msg;
    public Text pauseUIScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deathzone"))
        {
            Failed();
        }

        if (other.CompareTag("Finish"))
        {
            ScoreManager.instance.AddScore(Timer.instance.getTimeRemaining());
            Pause();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        inGameUI.SetActive(false);
        if (PlayerPrefs.GetInt("RunScore" + SceneManager.GetActiveScene().name) > PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name))
        {
            msg.text = "New Highscore";
        }
        else
        {
            msg.text = "You Finished";
        } 
        pauseUIScore.text = "Your Score: " + PlayerPrefs.GetInt("RunScore" + SceneManager.GetActiveScene().name);
    }
    void Failed()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        inGameUI.SetActive(false);
        msg.text = "You Failed";
    }
    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
