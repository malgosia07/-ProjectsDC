using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    public void changeLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void exitGame()
    {
        Application.Quit();
    }
    
}
