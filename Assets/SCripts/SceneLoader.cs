using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //CONFIG PARAMS
    int currentScene;

    //CANVAS BUTTON
    public void OnReloadGamePress()
    {
        //TURN ON THE TIME AND LOAD THE SCENE
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }
    //CANVAS BUTTON
    public void OnQuitGamePress()
    {
        Application.Quit();
    }
}
