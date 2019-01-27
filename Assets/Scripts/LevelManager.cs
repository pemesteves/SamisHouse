using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void loadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    public void loadMenu()
    {
        loadLevel("Menu");
    }

}
