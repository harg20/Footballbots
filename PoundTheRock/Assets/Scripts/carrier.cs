using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class carrier : MonoBehaviour
{
    public bool tagged = false;
    public float stamina = 100;
    public GameObject stamUI;
    
    float rott;
    float xSpeed;
    float zSpeed;
    float boosttime;
    float deadtimer = 0;
    public float speed;
    public int rotspeed;
    public GameObject Ball;
    
    bool canjump = true;
    bool truck = false;
    bool notrolling = true;
    int jumps = 0;
    bool boost = false;
    float boostr;
    // Start is called before the first frame update
    void Start()
    {
        deadtimer = 0;
        boostr = (speed * 2);
        stamUI = GameObject.FindGameObjectWithTag("feet");
       
       

    }
    private void OnCollisionEnter(Collision col)
    {
       
        
            if (col.gameObject.tag == "Dfense" )
            {
            if (boost == true)
            {
                if (col.gameObject.GetComponent<Rigidbody>())
                {
                    col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 1);
                }
                stamina -= 25;
                //truck = false;
                
            }
            else
            {


                tagged = true;
             
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //gameObject.GetComponent<Rigidbody>().useGravity= true;


                if (Ball.transform.parent == gameObject.transform)
                {
                  
                    Ball.GetComponent<Rigidbody>().isKinematic = false;
                    Ball.GetComponent<Rigidbody>().useGravity = true;
                    Ball.transform.parent = null;
                }
                //Time.timeScale = 0;

            }
            }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        canjump = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (stamUI)
        { 
        stamUI.GetComponent<RectTransform>().sizeDelta = new Vector2(stamina * 2, 50);
        }
        

    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (stamina < 100)
        {
            stamina += .3f;
        }
        
        if (!tagged)
        {
           /* if (Input.GetKeyDown(KeyCode.E))
            {
                truck = true;
            }*/

            if (Input.GetKeyDown(KeyCode.Space)&& canjump == true && stamina > 0)
            {
                gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 300, 100);
                canjump = false;
                 stamina -= 50;
            }
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
            {
                
                boost = true;
                speed = boostr;
                stamina -= 1;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && boost == true || Input.GetKey(KeyCode.LeftShift) && stamina <= 0)
            {
           
                    speed = speed * (0.5f);
                    
                    boost = false;
                

            }

            if (!Input.anyKey && canjump == true && jumps == 0 )
            {
                transform.Translate(new Vector3(0f, 0f, 0f));
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -5, 0);
               
            }
            else if (notrolling == true && tagged != true)
            {


                if (Input.GetKey(KeyCode.A))
                {
                    rott -= rotspeed;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rott += rotspeed;
                }
                transform.rotation = Quaternion.Euler(0f, rott, 0f);

                // xSpeed = Input.GetAxis("Horizontal") * speed;
                zSpeed = Input.GetAxis("Vertical") * (speed);

                transform.Translate(new Vector3(xSpeed, 0f, zSpeed));
            }
        }
       /* else
        {
            deadtimer += Time.deltaTime;
            if (deadtimer >= 1f)
            {
                tagged = false;
                deadtimer = 0;
            }
        }*/
       
    }

    }


