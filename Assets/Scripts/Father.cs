using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father : MonoBehaviour
{
    
    public float check_delay_after_sound = 1.5f;
    public Color sleep_color;
    public Color wake_color;

    private AudioSource audioSource;
    private GameObject furniture;
    private PlayerMovement player;
    private GameObject father_bed;

    private int minWait = 2;
    private int maxWait = 6;

    private bool started = false;

    // Update is called once per frame
    void Update()
    {
        if (!started && !GameObject.FindObjectOfType<TextBox>()) {
            furniture = GameObject.Find("Furniture");
            audioSource = GetComponent<AudioSource>();
            player = GameObject.FindObjectOfType<PlayerMovement>();
            father_bed = GameObject.Find("father_bed");
            var x = Random.Range(minWait, maxWait);
            Invoke("wake_up_father", x);
            started = true;
        }

    }

    private void wake_up_father()
    {
        audioSource.Play();
        father_bed.GetComponent<SpriteRenderer>().color = wake_color;

        Invoke("check_if_player_hiding", check_delay_after_sound);
    }

    private void check_if_player_hiding()
    {
        bool hiding = false;
        foreach (Transform child in furniture.transform)
        {
            if (child.gameObject.GetComponent<HidePlayer>().is_hiding())
                hiding = true;
        }
        if (!hiding)
        {
            player.UpdateLives();
        }

        reset_background();
        var x = Random.Range(minWait, maxWait);
        Invoke("wake_up_father", x);

    }

    private void reset_background()
    {
        father_bed.GetComponent<SpriteRenderer>().color = sleep_color;
    }
}
