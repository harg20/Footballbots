using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blocker : MonoBehaviour
{
    int i =0;
    public bool tagged = false;
    public bool newtarg = false;
    public bool roamblocking = true;
    public int blockforce = 200;
    bool hasstunned = false;
    public GameObject destination;
    float mass;

    
    
    public GameObject[] defenders;

    public GameObject[] blockers;
    
    public GameObject endzone;
    // Start is called before the first frame update
    void Start()
    {
        hasstunned = false;
        defenders = GameObject.FindGameObjectsWithTag("Dfense");
        mass = GetComponent<Rigidbody>().mass;
        
        i = Random.Range(0, defenders.Length);
        
    }
    private void OnCollisionEnter(Collision col)
    {
      
        if (col.gameObject.tag == "Dfense" && hasstunned == false)
        {
            Debug.Log("boing");
            Rigidbody colbod = col.gameObject.GetComponent<Rigidbody>();
            float colmass = colbod.mass;
            colbod.isKinematic = false;
            colbod.AddExplosionForce(blockforce* (1+(mass - colmass)) ,transform.position, 1,2);

            //hasstunned = true;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (roamblocking)
        {
            if (!newtarg)
            {
                GetComponent<NavMeshAgent>().SetDestination(defenders[i].transform.position);
            }

            float j = 10;
            float bd = gameObject.GetComponent<NavMeshAgent>().remainingDistance;
            foreach (GameObject defender in defenders)
           {
                
                float d = defender.GetComponent<NavMeshAgent>().remainingDistance;
                

                if (d < j && bd < 5f)
                {
                    
                    j = d;
                    
                    GetComponent<NavMeshAgent>().SetDestination(defender.transform.position);
                    newtarg = true;
                }

           }
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(destination.transform.position);
        }
    }
}
