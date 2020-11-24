using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Reciever : MonoBehaviour
{
  
    public Transform endzone;
    public GameObject Gmgr;
    
    public bool selected = false;
    public bool go = false;
    public List<Vector3> route;
    bool iscarrier = false;
    int i = 0;
    LineRenderer lrr;
    public bool hasroute = false;

    // Start is called before the first frame update
    void Start()
    {
        endzone = GameObject.Find("endz").transform;
        Gmgr = GameObject.Find("GameManager");
        //route = Gmgr.GetComponent<GameManager>().routespots;
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ball")
        {
           // col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            col.gameObject.GetComponent<ParabolaController>().StopFollow();
            //col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //GetComponent<Rigidbody>().useGravity = true;
            col.gameObject.GetComponent<Transform>().SetParent(transform);
            transform.tag = "carrier";
            Gmgr.GetComponent<GameManager>().Carrier = gameObject;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<carrier>().enabled = true;
            GetComponent<carrier>().tagged = false;
           Camera.main.GetComponent<CameraFollow>().target = transform;
            iscarrier = true;
          

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (go == true)
        {
            if (iscarrier == false)
            {
                if (hasroute == false && GetComponent<NavMeshAgent>().enabled)
                {
                    GetComponent<NavMeshAgent>().destination = endzone.position;
                }
                else
                {
                    if (GetComponent<NavMeshAgent>().enabled)
                    {
                        GetComponent<NavMeshAgent>().destination = route[i];
                        if (Vector3.Distance(transform.position, route[i]) < 1 && i < route.Count - 1)
                        {
                            i++;
                        }
                        if (i >= route.Count)
                        {
                            GetComponent<NavMeshAgent>().destination = endzone.position;
                        }
                    }
                }
                //GetComponent<NavMeshAgent>().destination = endzone.position;
            }
        }
    }
}
