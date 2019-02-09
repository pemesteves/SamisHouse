using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chest : MonoBehaviour
{
    private Animator ui_fader;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        ui_fader = GameObject.Find("FinalLevel_UI").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && collision.gameObject.transform.tag == "Player")
        {
            anim.SetTrigger("Open");
            ui_fader.SetTrigger("fade_animation");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            Invoke("destroy_eagles", 2.5f);
        }
    }

    private void destroy_eagles()
    {
        GameObject[] eagles = GameObject.FindGameObjectsWithTag("Eagle");
        foreach (var eagle in eagles)
        {
            eagle.SetActive(false);
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CapsuleCollider2D>().enabled = true;
        ui_fader.SetTrigger("end_game");
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
