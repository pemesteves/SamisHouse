using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public string next_level;
    private LevelManager lvlManager;

    // Start is called before the first frame update
    void Start()
    {
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && other.gameObject.transform.tag == "Player") //Agarrar
        {
            // Load new level
            lvlManager.loadLevel(next_level);
        }
    }
}
