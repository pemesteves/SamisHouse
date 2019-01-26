using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    private float fox_move=0f;
    private float dir = 1f;
    private Animator anim;



    public float max_mov = 10f;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(speed * dir, 0, 0);
        fox_move += speed;
        if (fox_move > max_mov)
        {
            fox_move = 0;
            dir *= -1f;
            anim.SetTrigger("change_dir");

        }

        //Vector3 diff = transform.Position();
    }
}
