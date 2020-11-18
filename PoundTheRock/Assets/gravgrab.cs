using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravgrab : MonoBehaviour
{
    public GameObject Planet;

    float planetmass = 1;
   float sunmass = 1000000000;
    Vector3 startvelocity = new Vector3(0.5f, 0, .5f);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball" && !other.transform.parent)
        {
            Planet = other.gameObject;
            Planet.GetComponent<Rigidbody>().AddForce(startvelocity, ForceMode.VelocityChange);
        }
    }
    public Vector3 calculateForce()
    {
        float distance = Vector3.Distance(transform.position, Planet.transform.position);

        float G = 6.67f * Mathf.Pow(10, -11);

        float force = G* sunmass * planetmass / (distance * distance);

        Vector3 fwd = (force * (transform.position - Planet.transform.position));

        return (fwd);

    }
    // Update is called once per frame
    void Update()
    {
        if (Planet)
        {
            Planet.GetComponent<Rigidbody>().AddForce(calculateForce(), ForceMode.Impulse);
        }
    }
}
