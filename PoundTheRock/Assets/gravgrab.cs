using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class gravgrab : MonoBehaviour
{
    public GameObject Planet;
    public GameObject Ball;

    float planetmass = 1;
   float sunmass = 1000000000;
    Vector3 startvelocity = new Vector3(0.5f, 0, .5f);
    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("ball");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball" && !Ball.transform.parent)
        {
            
            Planet = other.gameObject;
           
            Planet.GetComponent<Rigidbody>().AddForce(startvelocity, ForceMode.VelocityChange);
           
        }

        if ((other.tag == "rec"))
        {

            Planet = other.gameObject;
            Planet.GetComponent<Rigidbody>().AddForce(Planet.GetComponent<NavMeshAgent>().velocity, ForceMode.VelocityChange);
            Planet.GetComponent<NavMeshAgent>().enabled = false;
           

        }
        if (other.tag == "carrier")
        {
            Planet = other.gameObject;
            Planet.GetComponent<Rigidbody>().AddForce(Planet.GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);

            if (Ball.transform.parent.parent == Planet.transform)
            {
                Ball.GetComponent<Rigidbody>().isKinematic = true;
            }
          
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Planet)
        {
           
            Planet.GetComponent<Rigidbody>().AddForce(calculateForce(), ForceMode.Impulse);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "rec")
        {
            other.GetComponent<NavMeshAgent>().enabled = true;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (other.tag == "ball" && !other.transform.parent)
        {
            other.GetComponent<Rigidbody>().useGravity = true;
            Planet = null;

        }
        if (other.tag == "carrier")
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().isKinematic = false;
           
            if (Ball.transform.parent.parent == other.transform)
            {
                Ball.GetComponent<Rigidbody>().isKinematic = false;
            }

            Planet = null;
        }



    }
    
    public Vector3 calculateForce()
    {
        float distance = Vector3.Distance(transform.position, Planet.transform.position);

        float G = 6.67f * Mathf.Pow(10, -11);
      
        float force = G* sunmass * planetmass / (distance * distance);
        if (Planet.tag != "ball")
        {
            Debug.Log("gravitate " + Planet.tag);
            Vector3 fwd = (force * (new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(Planet.transform.position.x, 0, Planet.transform.position.z)));
            return (fwd);
        }
        else
        {
            Vector3 fwd = (force * (transform.position - Planet.transform.position));
            return (fwd);
        }

     

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
