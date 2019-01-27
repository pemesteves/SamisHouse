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
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.transform.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl) && !ended)
        {
            anim.SetTrigger("fade_animation");
            ended = true;
            Invoke("spawn_dead_stuff", 2.5f);
        } 
    }

    private void spawn_dead_stuff()
    {
        dead_stuff.SetActive(true);
        GameObject.FindObjectOfType<PlayerMovement>().gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;

        Invoke("end_game", 10f);
    }

    private void end_game()
    {
        player_lives.recover_full_health();
        lvl_manager.loadMenu();
    }
}
