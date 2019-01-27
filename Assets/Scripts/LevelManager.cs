using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        Application.LoadLevel("Level 1");
    }

    public void loadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
