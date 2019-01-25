using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool startJump;
    private Rigidbody2D rigidBody;
    private float jumpInitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        startJump = false;
        rigidBody = this.GetComponent<Rigidbody2D>();
        jumpInitialPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= jumpInitialPosition)
        {
            startJump = false;
        }

        if (Input.GetKeyDown(KeyCode.W)) //Saltar
        {
            if (!startJump)
            {
                startJump = true;
                jumpInitialPosition = transform.position.y;
                rigidBody.AddForce(Vector2.up * 300f);
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) //Baixar
        {
            rigidBody.AddForce(-Vector2.up * 300f);
        }

        if (Input.GetKey(KeyCode.D)) //Andar para a direita
        {
            transform.Translate(.1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.A)) //Andar para a esquerda
        {
            transform.Translate(-.1f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) //Agarrar
        {

        }
    }

}
