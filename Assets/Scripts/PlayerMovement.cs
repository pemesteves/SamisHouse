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
    private bool climb = false;

    // Start is called before the first frame update
    void Awake()
    {
        startJump = false;
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UI = GameObject.FindObjectOfType<UI_game>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        player_lives = GameObject.FindObjectOfType<PlayerLives>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walk_r)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (!jumping && !crouch)
                    anim.SetTrigger("walk");

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    transform.Translate(.15f, 0, 0);
                else
                    transform.Translate(.1f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftShift))
            {
                walk_r = false;
                walk_l = true;
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                walk_r = false;
                if (!jumping)
                {
                    if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !crouch)
                    {
                        anim.ResetTrigger("walk");
                        anim.SetTrigger("not_walk");
                    }
                }
            }

            if (!jumping)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    startJump = true;
                    jumping = true;
                    anim.SetTrigger("jump");
                    rigidBody.AddForce(Vector2.up * 500);
                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    crouch = true;
                    anim.SetTrigger("crouch");
                }
            }
        }

        if (walk_l)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (!jumping && !crouch)
                    anim.SetTrigger("walk");

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    transform.Translate(-.15f, 0, 0);
                else
                    transform.Translate(-.1f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                walk_r = true;
                walk_l = false;
                this.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                walk_l = false;
                if (!jumping)
                {
                    if (!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !crouch)
                    {
                        anim.ResetTrigger("walk");
                        anim.SetTrigger("not_walk");
                    }
                }
            }

            if (!jumping)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    startJump = true;
                    jumping = true;
                    anim.SetTrigger("jump");
                    rigidBody.AddForce(Vector2.up * 500);
                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    crouch = true;
                    anim.SetTrigger("crouch");
                }
            }
        }

        if (!walk_r && !walk_l)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (!jumping && !crouch)
                    anim.SetTrigger("walk");

                walk_l = true;
                this.GetComponent<SpriteRenderer>().flipX = true;

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    transform.Translate(-.15f, 0, 0);
                else
                    transform.Translate(-.1f, 0, 0);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (!jumping && !crouch)
                    anim.SetTrigger("walk");

                walk_r = true;
                this.GetComponent<SpriteRenderer>().flipX = false;

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    transform.Translate(.15f, 0, 0);
                else
                    transform.Translate(.1f, 0, 0);
            }

            if (!jumping)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    startJump = true;
                    jumping = true;
                    anim.SetTrigger("jump");
                    rigidBody.AddForce(Vector2.up * 500);
                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    crouch = true;
                    anim.SetTrigger("crouch");
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            crouch = false;
            anim.ResetTrigger("crouch");
            anim.SetTrigger("not_crouch");
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

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetTrigger("walk");
                walk_l = true;
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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

        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))&& other.gameObject.transform.tag == "Key") //Agarrar
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Key");
            if (obj != null)
            {
                audioManager.play_key_pickup();
                Destroy(obj);
                UI.Update_number_keys();
            }
        }

        if (other.gameObject.layer == LayerDetection.climbable)
        {
            anim.ResetTrigger("walk");
            anim.ResetTrigger("jump");
            anim.ResetTrigger("crouch");
            anim.ResetTrigger("interact");
            anim.SetBool("climb", true);
            this.GetComponent<SpriteRenderer>().flipX = false;
            rigidBody.velocity = Vector3.zero;
            this.GetComponent<Rigidbody2D>().gravityScale = 0;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                transform.Translate(0f, 0.1f * climb_speed, 0f);

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                transform.Translate(0f, -0.1f * climb_speed, 0f);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                walk_r = true;
                walk_l = false;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                walk_l = true;
                walk_r = false;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;

        if (collision.gameObject.layer == LayerDetection.climbable)
        {
            anim.SetBool("climb", false);
            this.GetComponent<Rigidbody2D>().gravityScale = 4;
            this.GetComponent<SpriteRenderer>().flipX = walk_l ? true : false;
        }
    }

    public void UpdateLives()
    {
        if (!player_lives)
            player_lives = GameObject.FindObjectOfType<PlayerLives>();

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