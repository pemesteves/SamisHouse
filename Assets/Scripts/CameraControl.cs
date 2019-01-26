using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float left_boundary;
    public float right_boundary;
    public float height;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float new_x = player.transform.position.x;

        new_x = new_x < left_boundary ? transform.position.x : new_x;
        new_x = new_x > right_boundary ? transform.position.x : new_x;

        transform.position = new Vector3(new_x, height, transform.position.z);

     
    }
}
