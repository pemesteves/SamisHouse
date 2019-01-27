using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnd : MonoBehaviour
{

    private Animator anim;

    private bool ended = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("UI").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.transform.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl) && !ended)
        {
            anim.SetTrigger("fade_animation");
            ended = true;
        } 
    }
}
