using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    public Sprite[] gem_img;
    private bool is_on = false;
    private SpriteRenderer img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<SpriteRenderer>();
        img.sprite = gem_img[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleGem()
    {
        is_on = !is_on;
        if (is_on)
            img.sprite = gem_img[1];
        else
            img.sprite = gem_img[0];
    }

    public bool getIsOn()
    {
        return is_on;
    }
}
