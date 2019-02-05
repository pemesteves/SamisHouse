using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crlh_fds : MonoBehaviour
{
    public AudioSource crlhfds;
    public Button samis_face;

    private void Start()
    {
        samis_face.onClick.AddListener(TaskOnClick); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        crlhfds.Play();
    }
}
