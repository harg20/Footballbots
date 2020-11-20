using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag != "rec" && other.gameObject.tag != "carrier")
        {
            GetComponent<ParabolaController>().StopFollow();
            GetComponent<Collider>().isTrigger = false;
            
         
            if(other.gameObject.tag != "blackhole")
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
