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
    public static LevelController instance;
    public void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deathzone"))
        {
            Failed();
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<AudioManager>().MuteSound("Theme");
        }

        if (other.CompareTag("Finish"))
        {
            ScoreManager.instance.AddScore(Timer.instance.GetTimeRemaining()*10);
            ScoreManager.instance.UpdateHighScore();
            Pause();
            FindObjectOfType<AudioManager>().Play("Goal");
            FindObjectOfType<AudioManager>().MuteSound("Theme");

        }
    }
    
    public void Pause()
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
    public void Failed()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        inGameUI.SetActive(false);
        msg.text = "You Failed";
    }
    public void RunOutOfTime()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        inGameUI.SetActive(false);
        msg.text = "You ran out of time";
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
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            BackToMenu();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
