using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cranks : MonoBehaviour
{
    public Sprite[] crank_img;
    private bool is_down = true;
    private SpriteRenderer img;
    public Gems[] gems;

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
        if(other.gameObject.transform.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (is_down)
            {
                is_down = false;
                img.sprite = crank_img[1];
                toggleGems();
            }
            else
            {
                is_down = true;
                img.sprite = crank_img[0];
                toggleGems();
            }
        }
    }

    private void toggleGems()
    {
        gems[0].toggleGem();
        gems[1].toggleGem();
        gems[2].toggleGem();
    }
    
}
