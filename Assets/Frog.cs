using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        int random_number = Random.Range(0, 2);
        anim

        if(random_number == 0)
        {
            anim.SetTrigger("jump");
        }
    }
}
