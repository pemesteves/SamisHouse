using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private uint jumpPosition;
    private bool startJump;
    private bool up;

    // Start is called before the first frame update
    void Start()
    {
        jumpPosition = 0;
        startJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //Saltar
        {
            if (!startJump)
            {
                startJump = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)) //Baixar
        {
            if (startJump)
            {
                up = false;
            }
        }
        else if (Input.GetKey(KeyCode.D)) //Andar para a direita
        {
            transform.Translate(.5f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A)) //Andar para a esquerda
        {
            transform.Translate(- .5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl)) //Agarrar
        {

        }
        /*else if (Input.GetKeyDown(")
        {

        }*/

        if (startJump == true)
        {
            jump();
        }
    }

    void jump()
    {
        if (jumpPosition < 100)
        {
            if (up)
            {
                transform.Translate(0, .5f, 0);
            }
            else
            {
                if (jumpPosition == 0)
                {
                    startJump = false;
                }
                else
                {
                    transform.Translate(0, -.5f, 0);
                }

            }
        }
        else if (jumpPosition == 100)
        {
            up = false;
        }

    }
}
