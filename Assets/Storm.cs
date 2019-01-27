using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{
    [RequireComponent(typeof(AudioSource))]
    public class ExampleScript : MonoBehaviour
    {
        AudioSource audioData;

        void Start()
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(100);
            Debug.Log("started");
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
