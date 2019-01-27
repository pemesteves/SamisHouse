using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip key_pickup;
    public AudioClip death_sound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_key_pickup()
    {
        audioSource.clip = key_pickup;
        audioSource.Play();
    }

    public void play_death_sound()
    {
        audioSource.clip = death_sound;
        audioSource.Play();
    }
}
