using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int lives { get; set; }

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
        Destroy(this);
        loadLevel("Menu");
    }

}
