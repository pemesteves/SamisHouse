using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float left_wall = -18f;
    private bool startJump;
    private Rigidbody2D rigidBody;
    private bool can_get_key;
    public UI_game UI;

    // Start is called before the first frame update
    void Start()
    {
        startJump = false;
        rigidBody = this.GetComponent<Rigidbody2D>();
        can_get_key = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //Saltar
        {
            if (!startJump)
            {
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
            if (can_get_key)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("key");
                Destroy(obj);
                UI.Update_number_keys();
            }
        }

        if (transform.position.x < left_wall)
            transform.position = new Vector3(left_wall, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.layer == LayerDetection.ground || obj.layer == LayerDetection.crate)
        {
            startJump = false;
        }
        else if (obj.layer == LayerDetection.water)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (layer == LayerDetection.destroy_player_trigger)
        {
            Destroy(gameObject);
        }
       /* else if (layer == LayerDetection.key)
        {
            can_get_key = true;
        }*/
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) //Agarrar
        {
            GameObject obj = GameObject.FindGameObjectWithTag("key");
            Destroy(obj);
            UI.Update_number_keys();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      /*  int layer = collision.gameObject.layer;
        if (layer == LayerDetection.key)
        {
            can_get_key = false;
        }*/
    }
}
