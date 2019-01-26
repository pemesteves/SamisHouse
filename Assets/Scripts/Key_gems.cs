using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_gems : MonoBehaviour
{
    public GameObject key;
    private bool has_key = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        bool all_on = true;

        foreach(Transform child in transform)
        {
            if (!child.gameObject.GetComponent<Gems>().getIsOn())
            {
                all_on = false;
            }
        }

        if (all_on && !has_key)
        {
            Instantiate(key, new Vector3(0.29f, 1.8f, 0f), Quaternion.identity);
            has_key = true;
        }
    }
}
