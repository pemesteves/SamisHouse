using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEagle : MonoBehaviour
{
    private bool spawned = false;
    private Vector3 nest_position;

    public GameObject eagle;

    // Start is called before the first frame update
    void Start()
    {
        nest_position = GameObject.Find("key").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            if (!GameObject.Find("key"))
            {
                Debug.Log("Key is gone");
                spawned = true;

                Invoke("spawn_eagle", 1);
            }
        }
    }

    private void spawn_eagle()
    {
        Instantiate(eagle, nest_position, Quaternion.identity);
    }
}
