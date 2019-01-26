using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBehaviour : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private float move_dir = 1;

    public float move_speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_dir = Vector3.Normalize(player.transform.position - transform.position);
        player_dir.z = 0f;

        if (player_dir.x * move_dir < 0)
        {
            anim.SetTrigger("change_dir");
            move_dir *= -1;
        }

        transform.position += player_dir * move_speed;
    }
}
