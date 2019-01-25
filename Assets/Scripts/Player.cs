using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool startJump;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        startJump = true;
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //Saltar
        {
            if (!startJump)
            {
                Debug.Log("Jump");
                startJump = true;
                rigidBody.AddForce(Vector2.up * 500);
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) //Baixar
        {

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        GameObject obj = collision.gameObject;
        if (obj.layer == 8)
        {
            startJump = false;
        }
    }
}
