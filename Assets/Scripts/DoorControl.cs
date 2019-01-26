using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class DoorControl : MonoBehaviour
{
    public string next_level;

    private LevelManager lvlManager;
    private Text keys;

    // Start is called before the first frame update
    void Start()
    {
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
        keys = GameObject.Find("Key_text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(Int32.Parse(keys.text.Split(' ')[1]));
        if (Input.GetKeyDown(KeyCode.LeftControl) && other.gameObject.transform.tag == "Player" && Int32.Parse(keys.text.Split(' ')[1]) > 0) //Agarrar
        {
            // Load new level
            lvlManager.loadLevel(next_level);
        }
    }
}
