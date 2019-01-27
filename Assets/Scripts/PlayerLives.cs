using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public int player_lives = 3;

    private int max_lives = 3;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player Lives");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void decrement_lives()
    {
        player_lives--;
    }

    public void recover_full_health()
    {
        player_lives = max_lives;
    }

    public void increment_lives()
    {
        player_lives++;
    }

    public bool is_player_dead()
    {
        return player_lives <= 0;
    }
}
