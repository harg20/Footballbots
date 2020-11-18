using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zonedefender : MonoBehaviour
{
    public GameObject targ;
    float unstun = 0;
    // Start is called before the first frame update
    void Start()
    {
        targ = GameObject.FindGameObjectWithTag("carrier");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rec")
        {
            targ = other.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,targ.transform.position) < 5)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = targ.transform.position;
        }
       
       
        if (!GetComponent<Rigidbody>().isKinematic)
        {
            unstun += Time.deltaTime;
            if (unstun >= 2f)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                Debug.Log("free");
                GetComponent<Rigidbody>().isKinematic = false;
                unstun = 0;
            }
        }
    }
}
