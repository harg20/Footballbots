using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "feet")
        {
            GetComponent<Rigidbody>().AddForce(0, 4.915f, 0);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "feet")
        {
            GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("clunk");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
