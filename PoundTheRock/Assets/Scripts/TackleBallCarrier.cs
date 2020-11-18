using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TackleBallCarrier : MonoBehaviour
{
    public GameObject carrier;
    float unstun = 0;

    // Start is called before the first frame update
    void Start()
    {
        

        /*int i = Random.Range(0, 2);
        if (i == 1)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * 2, gameObject.transform.localScale.z);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("carrier"))
        {
            carrier = GameObject.FindGameObjectWithTag("carrier");
        }
        gameObject.GetComponent<NavMeshAgent>().destination = carrier.transform.position;
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
