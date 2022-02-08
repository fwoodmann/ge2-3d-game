using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    public Slider volumeSlider;
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().MuteSound("ButtonHit");
        SceneManager.LoadScene(1);
    }

    //Important to name Levels and Button the same way!! Otherwise this wont work 
    //Level_X
    public void SelectLevel(Button btn)
    {
        SceneManager.LoadScene(btn.name);
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

    public void updateVolume()
    {
        //PlayerPrefs.SetFloat("volume",PlayerPrefs.GetFloat("volume"));
        Debug.Log(volumeSlider.value);
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        Debug.Log(PlayerPrefs.GetFloat("volume"));
    }

}
