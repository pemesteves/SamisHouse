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
        level_number = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(level_number);
        level.text = "LEVEL " + level_number.ToString();
        Debug.Log(level.text);
        number_keys = 0;
        keys.text = "= " + number_keys;
    }

    public void Update_number_keys()
    {
        number_keys += 1;
        keys.text = "= " + number_keys;
    }

}
