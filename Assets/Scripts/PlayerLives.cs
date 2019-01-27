using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public int player_lives = 3;

    private int max_lives = 3;

    private bool seen_level_dialog = false;

    // Start is called before the first frame update
    void Start()
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

    public int get_player_lives()
    {
        return player_lives;
    }

    public void mark_level_seen()
    {
        seen_level_dialog = true;
    }

    public void mark_level_not_seen()
    {
        seen_level_dialog = false;
    }

    public bool player_seen_level()
    {
        return seen_level_dialog;
    }
}
