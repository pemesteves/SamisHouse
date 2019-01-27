using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private PlayerMovement player;
    public TextBox_Text current;


    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        player.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!current.get_next_text())
            {
                player.enabled = true;
                Destroy(gameObject);
            }
            else
            {
                current = GameObject.FindObjectOfType<TextBox_Text>();
            }
        }
    }
}
