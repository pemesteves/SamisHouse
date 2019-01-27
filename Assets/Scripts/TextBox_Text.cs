using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox_Text : MonoBehaviour
{

    public GameObject next;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool get_next_text()
    {
        if (!next) return false;

        next.SetActive(true);
        gameObject.SetActive(false);
        return true;
    }
}
