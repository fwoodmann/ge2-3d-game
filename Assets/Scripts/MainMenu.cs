using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
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
}
