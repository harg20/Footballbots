using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CornerBack : MonoBehaviour
{
    public GameObject targ;
    float unstun = 0;
    // Start is called before the first frame update
    void Start()
    {
        targ = GameObject.FindGameObjectWithTag("carrier");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("rec").Length > 0)
        {
            float dist = 10;
            foreach (GameObject rec in GameObject.FindGameObjectsWithTag("rec"))
            {
                if (Vector3.Distance(transform.position,rec.transform.position) < dist)
                {
                    dist = Vector3.Distance(transform.position, rec.transform.position);
                    targ = rec;
                }
            }
        }
        gameObject.GetComponent<NavMeshAgent>().destination = targ.transform.position;
        if (!GetComponent<Rigidbody>().isKinematic)
        {
            unstun += Time.deltaTime;
            if (unstun >= 2f)
            {
                GetComponent<Rigidbody>().isKinematic = true;

                GetComponent<Rigidbody>().isKinematic = false;
                unstun = 0;
            }
        }
    }
}
