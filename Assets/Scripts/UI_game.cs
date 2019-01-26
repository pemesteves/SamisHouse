using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UI_game : MonoBehaviour
{
    public Text level;
    public Text keys;
    private int level_number;
    private int number_keys;

    // Start is called before the first frame update
    void Start()
    {
        level_number = Convert.ToInt32(level.text.Substring(6));
        SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
