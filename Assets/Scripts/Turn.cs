using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public Sprite[] crank_img;
    public bool down = true;
    private SpriteRenderer img;

    private GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<SpriteRenderer>();
        water = GameObject.Find("water");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player" && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)))
        {
            if (down)
            {
                down = false;
                img.sprite = crank_img[1];
                Destroy(water);
            }
        }
    }

}
