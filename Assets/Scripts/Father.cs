using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father : MonoBehaviour
{

    public float wake_interval_seconds = 4f;

    private AudioSource audioSource;
    private GameObject furniture;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        furniture = GameObject.Find("Furniture");
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindObjectOfType<PlayerMovement>();
        InvokeRepeating("wake_up_father", 2f, wake_interval_seconds);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void wake_up_father()
    {
        audioSource.Play();
        Invoke("check_if_player_hiding", 2f);
    }

    private void check_if_player_hiding()
    {
        bool hiding = false;
        foreach (Transform child in furniture.transform)
        {
            if (child.gameObject.GetComponent<HidePlayer>().is_hiding())
                hiding = true;
        }
        if (!hiding)
        {
            player.UpdateLives();
        }
    }
}
