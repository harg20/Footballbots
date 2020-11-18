using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchArm : MonoBehaviour
{
    public GameObject target;
    bool caught = false;
    float go = 0;
    float reverse = 0;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = target.transform.localPosition;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ball" && caught == false)
        {
            go += .05f;
            target.transform.position = Vector3.Lerp(target.transform.position, other.transform.position, go);
            if (go >= 1)
            {
                other.transform.parent = target.transform;
                caught = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (caught)
        {
            if (reverse <1)
        {
            reverse += .01f;
            target.transform.localPosition = Vector3.Lerp(target.transform.localPosition, new Vector3(startpos.x, startpos.y - 1, startpos.z - 1.5f), reverse);
        }

        if (!transform.GetComponentInChildren<ball>())
            {
                transform.GetComponent<carrier>().enabled = false;
                transform.tag = "Player";
            }
       /*if (reverse >= 1)
            {
                target.transform.localPosition = Vector3.Lerp(target.transform.localPosition, new Vector3(startpos.x, startpos.y-1, startpos.z - 1.5f), reverse);
            }
            */

        }
    }
}
