using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private PlayerMovement player;
    private PlayerLives player_lives;

    public TextBox_Text current;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        player_lives = GameObject.FindObjectOfType<PlayerLives>();
        player.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_lives)
            player_lives = GameObject.FindObjectOfType<PlayerLives>();

        if (player_lives.player_seen_level())
        {
            player.enabled = true;
            Destroy(GameObject.Find("player_dialog_img"));
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!current.get_next_text())
            {
                player.enabled = true;
                player_lives.mark_level_seen();
                Destroy(GameObject.Find("player_dialog_img"));
                Destroy(gameObject);
            }
            else
            {
                current = GameObject.FindObjectOfType<TextBox_Text>();
            }
        }
    }
}
