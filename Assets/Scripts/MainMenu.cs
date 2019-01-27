using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("1"))
        {
            SceneManager.LoadScene("Level 1");
        }

        if (Input.GetKey("2"))
        {
            SceneManager.LoadScene("Level 2");
        }

        if (Input.GetKey("3"))
        {
            SceneManager.LoadScene("Level 3");
        }

        if (Input.GetKey("4"))
        {
            SceneManager.LoadScene("Level 4");
        }

        if (Input.GetKey("5"))
        {
            SceneManager.LoadScene("Level 5");
        }

        if (Input.GetKey("6"))
        {
            SceneManager.LoadScene("Level 6");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
