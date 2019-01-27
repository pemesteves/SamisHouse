using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSound : MonoBehaviour
{
    public void PlayThunderSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
