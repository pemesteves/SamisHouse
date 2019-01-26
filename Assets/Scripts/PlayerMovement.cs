using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float left_wall;
    public float right_wall;
    public float climb_speed = 1;

    public bool startJump;
    private Rigidbody2D rigidBody;
    private bool can_get_key;
    private UI_game UI;
    private Animator anim;

    private bool colliding = false;
    private bool grounded = false;
    private bool crouch = false;
    private bool walking_r = false;
    private bool walking_l = false;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        startJump = false;
        rigidBody = this.GetComponent<Rigidbody2D>();
        can_get_key = false;
        anim = gameObject.GetComponentInChildren<Animator>();
        UI = GameObject.FindObjectOfType<UI_game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jumping && !crouch && !walking_r && !walking_l)    // JUMP  CROUCH  DIRECTION
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetTrigger("jump");
                startJump = true;
                rigidBody.AddForce(Vector2.up * 150);
                jumping = true;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetTrigger("crouch");
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetTrigger("walk");
                walking_l = true;
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetTrigger("walk");
                walking_r = true;
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (crouch)                    // STOP CROUCH
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.ResetTrigger("crouch");
                anim.SetTrigger("not_crouch");
            }
        }
        else if (walking_r || jumping)     // WALKING RIGHT
        {
            if(Input.GetKey(KeyCode.W) && walking_r && !jumping)
            {
                anim.SetTrigger("jump");
                startJump = true;
                rigidBody.AddForce(Vector2.up * 150);
                jumping = true;
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
                transform.Translate(.15f, 0, 0);
            else if(Input.GetKey(KeyCode.D))
                transform.Translate(.1f, 0, 0);

            if (Input.GetKeyUp(KeyCode.D) && !jumping)
            {
                anim.ResetTrigger("walk");
                anim.SetTrigger("not_walk");
                walking_r = false;
            }
        }
        else if (walking_l || jumping)     //WALKING LEFT
        {
            if (Input.GetKey(KeyCode.W) && walking_l && !jumping)
            {
                anim.SetTrigger("jump");
                startJump = true;
                rigidBody.AddForce(Vector2.up * 150);
                jumping = true;
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
                transform.Translate(-.15f, 0, 0);
            else if (Input.GetKey(KeyCode.A))
                transform.Translate(-.1f, 0, 0);

            if (Input.GetKeyUp(KeyCode.A) && !jumping)
            {
                anim.ResetTrigger("walk");
                anim.SetTrigger("not_walk");
                walking_l = false;
            }
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



        /*
        if (Input.GetKeyDown(KeyCode.W) && !colliding) //Saltar
        {
            if (!startJump)
            {
                startJump = true;
                anim.SetTrigger("jump");
                anim.enabled = true;
                rigidBody.AddForce(Vector2.up * 500);
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) //Baixar
        {
            anim.SetTrigger("crouch");
            anim.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("not_crouch");
        }

        if (Input.GetKey(KeyCode.D)) //Andar para a direita
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.Translate(.15f, 0, 0);
            else
                transform.Translate(.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!crouch)
            {
                anim.SetTrigger("walk");
                anim.enabled = true;
            }
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (!crouch)
            {
                anim.SetTrigger("not_walk");
                anim.enabled = false;
            }
    }

        if (Input.GetKey(KeyCode.A)) //Andar para a esquerda
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.Translate(-.15f, 0, 0);
            else
                transform.Translate(-.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!crouch)
            {
                anim.SetTrigger("walk");
                anim.enabled = true;
            }

            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (!crouch)
            {
                anim.SetTrigger("not_walk");
                anim.enabled = false;
            }
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

        if (transform.position.x > right_wall)
            transform.position = new Vector3(right_wall, transform.position.y, transform.position.z);*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.layer == LayerDetection.ground || obj.layer == LayerDetection.crate)
        {
            startJump = false;
            anim.SetTrigger("reach_ground");
        }
        else if (obj.layer == LayerDetection.water)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerDetection.ground)
        {
            rigidBody.gravityScale = 0.1f;
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (grounded)
        {
            grounded = false;
            rigidBody.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (layer == LayerDetection.destroy_player_trigger)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag != "Key" && !other.GetComponent<DoorControl>() && other.gameObject.transform.tag != "Crank")
            colliding = true;

        if (Input.GetKeyDown(KeyCode.LeftControl) && other.gameObject.transform.tag == "Key") //Agarrar
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Key");
            if (obj != null)
            {
                Destroy(obj);
                UI.Update_number_keys();
            }
        }
        /*
        else if(Input.GetKeyDown(KeyCode.LeftControl) && other.gameObject.transform.tag == "Crank")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Crank");
            if(obj != null)
            {
                Animator crank_anim = obj.GetComponent<Animator>();
                crank_anim.SetTrigger("Interact");
            }
        }*/

        if (Input.GetKey(KeyCode.W) && other.gameObject.layer == LayerDetection.climbable)
        {
            rigidBody.velocity = Vector3.zero;
            transform.Translate(0f, 0.1f * climb_speed, 0f);
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (Input.GetKey(KeyCode.S) && other.gameObject.layer == LayerDetection.climbable)
        {
            transform.Translate(0f, -0.1f * climb_speed, 0f);
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;

        if(collision.gameObject.layer == LayerDetection.climbable)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 4;
        }
    }
}

    public bool colliding = false;
            jumping = false;
            anim.ResetTrigger("jump");