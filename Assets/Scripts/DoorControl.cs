using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using UnityEngine.SceneManagement;


public class DoorControl : MonoBehaviour
{
    public string next_level;

    public AudioClip door_open;

   private AudioSource doorSound;

    private LevelManager lvlManager;
    private Text keys;
    
    // Start is called before the first frame update
    void Start()
    {
        doorSound = GetComponent<AudioSource>();
        lvlManager = GameObject.FindObjectOfType<LevelManager>();

        keys = GameObject.Find("Key_text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && (scene.name == "Final Level" || scene.name == "Roof"))
        {
            door_open = doorSound.clip;
            doorSound.Play();
            lvlManager.loadLevel(next_level);
        }
        else if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && other.gameObject.transform.tag == "Player" && Int32.Parse(keys.text.Split(' ')[1]) > 0) //Agarrar
        {
            // Load new level
            door_open = doorSound.clip;
            doorSound.Play();
            lvlManager.loadLevel(next_level);
        }
    }
}
