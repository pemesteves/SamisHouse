using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelLoader : MonoBehaviour
{
    private LevelManager lvl_manager;

    void Start()
    {
        lvl_manager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.transform.tag == "Player")
        {
            lvl_manager.loadLevel("Final Level");
        }
    }
}
