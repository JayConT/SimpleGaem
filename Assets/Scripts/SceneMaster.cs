using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public OptionsManager options;
    public GameObject optionsPanel;
    public GameObject menuScreen;

    void Start()
    {
        options = GameObject.FindGameObjectWithTag("Options").GetComponent<OptionsManager>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsOpen()
    {
        optionsPanel.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void OptionsClose()
    {
        optionsPanel.SetActive(false);
        menuScreen.SetActive(true);
        options.SaveOptions();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
