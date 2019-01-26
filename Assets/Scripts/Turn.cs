using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public Sprite[] crank_img;
    private bool is_down = true;
    private SpriteRenderer img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (is_down)
            {
                is_down = false;
                img.sprite = crank_img[1];
            }
            else
            {
                is_down = true;
                img.sprite = crank_img[0];
            }
        }
    }
}
