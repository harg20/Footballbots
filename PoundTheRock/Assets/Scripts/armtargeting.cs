using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armtargeting : MonoBehaviour
{
    public GameObject larm;
    public GameObject rarm;
    Vector3 lstart;
    Vector3 rstart;
    bool blocking = false;
    float a = 0;
    float b = 0;
    // Start is called before the first frame update
    void Start()
    {
        lstart = larm.transform.localPosition;
        rstart = rarm.transform.localPosition;
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.transform.parent.tag == "Ofense" && other.tag == "Dfense")
        {
            larm.transform.position = Vector3.Lerp(larm.transform.position,other.gameObject.transform.position,a);
            rarm.transform.position = Vector3.Lerp(rarm.transform.position, other.gameObject.transform.position, a);
            blocking = true;
            b = 0;
            if (a < 1)
            {
                a += .01f;
            }
        }
        if(gameObject.transform.parent.tag == "Dfense" && other.tag == "Ofense")
        {
            larm.transform.position = Vector3.Lerp(larm.transform.position, other.gameObject.transform.position, a);
            rarm.transform.position = Vector3.Lerp(rarm.transform.position, other.gameObject.transform.position, a);
            blocking = true;
            b = 0;
            Debug.Log("got");
            if (a < 1)
            {
                a += .01f;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.transform.parent.tag == "Ofense" && other.tag == "Dfense" )
        {
            blocking = false;
        }
        if ( gameObject.transform.parent.tag == "Dfense" && other.tag == "Ofense")
        {
            blocking = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!blocking)
        {
            a = 0;
            larm.transform.localPosition = Vector3.Lerp(larm.transform.localPosition,lstart,b);
            rarm.transform.localPosition = Vector3.Lerp(rarm.transform.localPosition, rstart, b);
            if (b < 1)
            {
                b += .01f;
            }
        }
    }
}
