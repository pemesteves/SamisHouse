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
    private UI_game UI;
    private Animator anim;
    private AudioManager audioManager;
    private LevelManager levelManager;
    private PlayerLives player_lives;

    public bool colliding = false;
    private bool grounded = false;

    private bool jumping = false;
    private bool walk_r = false;
    private bool walk_l = false;
    private bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        startJump = false;
        rigidBody = this.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        UI = GameObject.FindObjectOfType<UI_game>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        player_lives = GameObject.FindObjectOfType<PlayerLives>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!jumping && !walk_r && !walk_l && !crouch)
        {
            if (Input.GetKeyDown(KeyCode.W)) //Saltar
            {
                startJump = true;
                jumping = true;
                anim.SetTrigger("jump");
                rigidBody.AddForce(Vector2.up * 500);
            }

            if (Input.GetKeyDown(KeyCode.S)) //Baixar
            {
                crouch = true;
                anim.SetTrigger("crouch");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                walk_r = true;
                anim.SetTrigger("walk");
                this.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                walk_l = true;
                anim.SetTrigger("walk");
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (jumping)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    transform.Translate(.15f, 0, 0);
                else
                    transform.Translate(.1f, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    transform.Translate(-.15f, 0, 0);
                else
                    transform.Translate(-.1f, 0, 0);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                walk_r = false;
                anim.ResetTrigger("walk");
                anim.SetTrigger("not_walk");
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                walk_l = false;
                anim.ResetTrigger("walk");
                anim.SetTrigger("not_walk");
            }
        }

        if (walk_r && !jumping)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    transform.Translate(.15f, 0, 0);
                else
                    transform.Translate(.1f, 0, 0);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                walk_r = false;
                anim.ResetTrigger("walk");
                anim.SetTrigger("not_walk");
            }

            if (Input.GetKey(KeyCode.W))
            {
                startJump = true;
                jumping = true;
                anim.SetTrigger("jump");
                rigidBody.AddForce(Vector2.up * 500);
            }
        }

        if (walk_l && !jumping)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    transform.Translate(-.15f, 0, 0);
                else
                    transform.Translate(-.1f, 0, 0);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                walk_l = false;
                anim.ResetTrigger("walk");
                anim.SetTrigger("not_walk");
            }

            if (Input.GetKey(KeyCode.W))
            {
                startJump = true;
                jumping = true;
                anim.SetTrigger("jump");
                rigidBody.AddForce(Vector2.up * 500);
            }
        }

        if (crouch)
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                if (Input.GetKey(KeyCode.LeftShift))
                    transform.Translate(.15f, 0, 0);
                else
                    transform.Translate(.1f, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                if (Input.GetKey(KeyCode.LeftShift))
                    transform.Translate(-.15f, 0, 0);
                else
                    transform.Translate(-.1f, 0, 0);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetTrigger("not_crouch");
                anim.ResetTrigger("crouch");
                crouch = false;
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
            anim.ResetTrigger("jump");
            jumping = false;

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetTrigger("walk");
                walk_l = true;
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (Input.GetKey(KeyCode.D))
            {
                anim.SetTrigger("walk");
                walk_r = true;
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (obj.layer == LayerDetection.water)
        {
            UpdateLives();
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
            UpdateLives();
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

        if (collision.gameObject.layer == LayerDetection.climbable)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 4;
        }
    }

    private void UpdateLives()
    {
        player_lives.decrement_lives();
        if (player_lives.is_player_dead())
        {
            player_lives.recover_full_health();
            levelManager.loadMenu();
        }
        else
        {
            levelManager.RestartLevel();
        }
    }
}