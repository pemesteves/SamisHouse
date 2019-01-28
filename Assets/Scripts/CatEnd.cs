using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnd : MonoBehaviour
{

    private Animator anim;

    private bool ended = false;
    private LevelManager lvl_manager;
    private PlayerLives player_lives;

    public GameObject dead_stuff;

    private bool during_end_message = false;
    public GameObject final_text_box;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("UI").GetComponent<Animator>();
        lvl_manager = GameObject.FindObjectOfType<LevelManager>();
        player_lives = GameObject.FindObjectOfType<PlayerLives>();
    }

    // Update is called once per frame
    void Update()
    {
        if (during_end_message && Input.GetKeyDown(KeyCode.Return))
        {
            final_text_box.SetActive(false);
            during_end_message = false;
            anim.SetTrigger("end_game");

            Invoke("end_game", 10f);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.transform.tag == "Player" && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && !ended)
        {
            anim.SetTrigger("fade_animation");
            ended = true;
            during_end_message = true;
            Invoke("spawn_dead_stuff", 2.5f);
        } 
    }

    private void spawn_dead_stuff()
    {
        dead_stuff.SetActive(true);
        GameObject.FindObjectOfType<PlayerMovement>().gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;

        final_text_box.SetActive(true);
    }

    private void end_game()
    {
        player_lives.recover_full_health();
        lvl_manager.loadMenu();
    }
}
