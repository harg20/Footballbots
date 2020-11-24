using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class throwball : MonoBehaviour
{
    public List<GameObject> recievers;
    public Transform bolastart;
    public Transform bolamid;
    public Transform bolaend;
    public GameManager gmgr;
    
    int rec = 0;
    protected float anim;
    GameObject ball;
    bool thrown = false;
    int x;
    int y;
    int z;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.childCount > 0)
        {
            ball = transform.GetChild(0).gameObject;
        }
        
        foreach (GameObject reciever in GameObject.FindGameObjectsWithTag("rec"))
        {
            recievers.Add(reciever);
        }
        int x = Random.Range(-1, 2);
        int y = Random.Range(-1, 2);
        int z = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {

       
        if (recievers.Count > 0)
        {
            
            if (thrown == false)
            {
                bolastart.position = transform.position;
            }
            
            if (!transform.GetComponentInChildren<ball>())
            {
                transform.parent.GetComponent<carrier>().enabled = false;
                transform.parent.tag = "Player";
            }
            bolamid.position = new Vector3(bolaend.position.x - bolastart.position.x, ball.transform.position.y+20, bolaend.position.z - bolastart.position.z);

            bolaend.position = new Vector3(recievers[rec].transform.position.x+x, recievers[rec].transform.position.y+y, recievers[rec].transform.position.z+z);

            ball.transform.LookAt(recievers[rec].transform);
            // ball.transform.position = MathParabola.Parabola(ball.transform.position, recievers[0].transform.position,5f,anim/5);

            //ball.transform.LookAt(recievers[0].transform);

            if (Input.GetKeyDown(KeyCode.Alpha1) && thrown == false )
            {
                rec = 0;
                
                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.GetComponent<ParabolaController>().FollowParabola();
                Camera.main.GetComponent<CameraFollow>().target = ball.transform;
                transform.parent.GetComponent<carrier>().enabled = false;
                transform.parent.tag = "Player";
                gmgr.Carrier = null;
                transform.DetachChildren();
                thrown = true;
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && thrown == false && recievers.Count > 1)
            {


                rec = 1;

                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.GetComponent<ParabolaController>().FollowParabola();
                Camera.main.GetComponent<CameraFollow>().target = ball.transform;
                transform.parent.GetComponent<carrier>().enabled = false;
                transform.parent.tag = "Player";
                gmgr.Carrier = null;
                transform.DetachChildren();
                thrown = true;

            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && thrown == false && recievers.Count > 2)
            {


                rec = 2;

                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.GetComponent<ParabolaController>().FollowParabola();
                Camera.main.GetComponent<CameraFollow>().target = ball.transform;
                transform.parent.GetComponent<carrier>().enabled = false;
                transform.parent.tag = "Player";
                gmgr.Carrier = null;
                transform.DetachChildren();
                thrown = true;

            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && thrown == false && recievers.Count > 3)
            {


                rec = 3;

                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.GetComponent<ParabolaController>().FollowParabola();
                Camera.main.GetComponent<CameraFollow>().target = ball.transform;
                transform.parent.GetComponent<carrier>().enabled = false;
                transform.parent.tag = "Player";
                gmgr.Carrier = null;
                transform.DetachChildren();
                thrown = true;

            }
        }
        
           
        
    }
}
