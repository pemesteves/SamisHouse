using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{

    private bool hiding = false;
    private bool first_plane = false;
    private SpriteRenderer sprite_render;

    // Start is called before the first frame update
    void Start()
    {
        sprite_render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && coll.gameObject.transform.tag == "Player")
        {
            hiding = !hiding;
            sprite_render.sortingOrder = sprite_render.sortingOrder == 0 ? 5 : 0;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.transform.tag == "Player")
        {
            hiding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.transform.tag == "Player" && hiding)
        {
            hiding = false;
            //sprite_render.sortingOrder = 5;
        }
    }

    public bool is_hiding()
    {
        return hiding;
    }
}
