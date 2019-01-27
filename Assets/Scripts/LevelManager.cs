using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] hearts = new GameObject[3];
    public PlayerLives player_lives_obj;

    void Start()
    {
        hearts[0] = GameObject.Find("Heart1");
        hearts[1] = GameObject.Find("Heart2");
        hearts[2] = GameObject.Find("Heart3");
        player_lives_obj = GameObject.FindObjectOfType<PlayerLives>();
        
        update_heart_containers();
    }

    void Update()
    {
        if(!player_lives_obj)
        {
            player_lives_obj = GameObject.FindObjectOfType<PlayerLives>();
            update_heart_containers();
        }
    }


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

    public void update_heart_containers()
    {
        int player_lives = player_lives_obj.get_player_lives();

        if (player_lives == 3)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
        }
        else if (player_lives == 2)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(false);
        }
        else if (player_lives == 1)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
        }
        else
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
        }
    }
}
