using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cranks : MonoBehaviour
{
    public Sprite[] crank_img;
    private bool is_down = true;
    private SpriteRenderer img;
    public Gems[] gems;
    public int crank_id;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<SpriteRenderer>();

        switch (crank_id)
        {
            case 1:
                gems[0] = GameObject.Find("gem1").GetComponent<Gems>();
                gems[1] = GameObject.Find("gem3").GetComponent<Gems>();
                gems[2] = GameObject.Find("gem4").GetComponent<Gems>();
                break;
            case 2:
                gems[0] = GameObject.Find("gem2").GetComponent<Gems>();
                gems[1] = GameObject.Find("gem4").GetComponent<Gems>();
                gems[2] = GameObject.Find("gem5").GetComponent<Gems>();
                break;
            case 3:
                gems[0] = GameObject.Find("gem3").GetComponent<Gems>();
                gems[1] = GameObject.Find("gem5").GetComponent<Gems>();
                gems[2] = GameObject.Find("gem1").GetComponent<Gems>();
                break;
            case 4:
                gems[0] = GameObject.Find("gem4").GetComponent<Gems>();
                gems[1] = GameObject.Find("gem1").GetComponent<Gems>();
                gems[2] = GameObject.Find("gem2").GetComponent<Gems>();
                break;
            case 5:
                gems[0] = GameObject.Find("gem5").GetComponent<Gems>();
                gems[1] = GameObject.Find("gem2").GetComponent<Gems>();
                gems[2] = GameObject.Find("gem3").GetComponent<Gems>();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.transform.tag == "Player" && (Input.GetKeyDown(KeyCode.LeftControl)|| Input.GetKeyDown(KeyCode.RightControl)))
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
