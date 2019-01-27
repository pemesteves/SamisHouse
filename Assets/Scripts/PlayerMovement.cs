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
    private AudioManager audioManager;
    private LevelManager levelManager;

    public bool colliding = false;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        startJump = false;
        rigidBody = this.GetComponent<Rigidbody2D>();
        can_get_key = false;
        anim = gameObject.GetComponentInChildren<Animator>();
        UI = GameObject.FindObjectOfType<UI_game>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !colliding) //Saltar
        {
            if (!startJump)
            {
                startJump = true;
                anim.SetTrigger("jump");
                rigidBody.AddForce(Vector2.up * 500);
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) //Baixar
        {
            anim.SetTrigger("crouch");
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
            anim.SetTrigger("walk");
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("not_walk");
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
            anim.SetTrigger("walk");
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("not_walk");
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
            transform.position = new Vector3(right_wall, transform.position.y, transform.position.z);
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
            levelManager.RestartLevel();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerDetection.ground)
        {
            rigidBody.gravityScale = 0.1f;
            grounded = true;
            //startJump = false;
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
            levelManager.RestartLevel();
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
                audioManager.play_key_pickup();
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
