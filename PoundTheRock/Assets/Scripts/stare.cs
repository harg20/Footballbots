using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stare : MonoBehaviour
{
    GameObject guy;
    // Start is called before the first frame update
    void Start()
    {
        guy = GameObject.FindGameObjectWithTag("carrier");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.tag != "carrier")
        {
            transform.LookAt(guy.transform);
            
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
