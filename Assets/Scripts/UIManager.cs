using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;
    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);

    }


    public void Return()
    {

        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void AnotherOptions()
    {

        SceneManager.LoadScene("Options");
    }

    public void GoMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() 
    {
        Application.Quit(); //para salir cuando generemos el ejecutable o la APK
    }
    public void PlaySoundButton()
    {
        clip.Play();
    }
}
