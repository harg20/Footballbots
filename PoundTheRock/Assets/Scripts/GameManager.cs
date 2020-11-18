using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Material selected;
    public bool UIclicked = false;
    public Material statik;
    public GameObject placeUIBlocker;
    public GameObject Blocker;
    public GameObject botblocker;
    public GameObject Throwball;
    public GameObject Blockerpicked;
    public GameObject Blockerbruiser;
    public GameObject reciever;
    public GameObject[] defenders;
    public List<GameObject> blockers;
    public List<GameObject> targblockers;

    public int BudgetUI;
    int unitcost;
    public int numrec = 0;
   
    public List<Vector3> routespots;
    public Material line;
    GameObject rec;
    
    RaycastHit hit;
    bool canplace = true;
    public bool drawroute = false;
    bool aiactive = false;

    // Start is called before the first frame update
    void Start()
    {
        numrec = 0;
        defenders = GameObject.FindGameObjectsWithTag("Dfense");
        //UIclicked = false;
        routespots = new List<Vector3>();
        canplace = true;
       
    }
    public void UIClick(GameObject name)
    {
        string nam = name.GetComponentInChildren<Text>().text;
        
        
        switch (nam)
        {
            case "Blocker":
                Blockerpicked = Blocker;
                unitcost = Blockerpicked.GetComponent<BotStats>().cost;
               // Debug.Log(Blockerpicked);
      
                break;

            case "Blockerbruiser":
                Blockerpicked = Blockerbruiser;
                unitcost = Blockerpicked.GetComponent<BotStats>().cost;
                //Debug.Log(nam);
                //Debug.Log(Blockerpicked);
                break;


            case "recr2":
                Blockerpicked = reciever;
                unitcost = Blockerpicked.GetComponent<BotStats>().cost;
                break;


            case "blockerupright":
                Blockerpicked = botblocker;
                unitcost = Blockerpicked.GetComponent<BotStats>().cost;
                break;

        }
        
        //Debug.Log(UIclicked);
    }

    public void SelectUnit()
    {
        if (hit.collider.gameObject.tag == "rec")
        {
            hit.collider.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material = selected;
            rec = hit.collider.gameObject;
            canplace = false;
            drawroute = true;
        }
        if (hit.collider.gameObject.tag == "Ofense")
        {
            targblockers.Add(hit.collider.gameObject);
            hit.collider.transform.GetChild(1).GetComponent<MeshRenderer>().material = selected;
        }

    }

    public void StartPlay()
    {
        canplace = false;
        foreach (GameObject blocker in blockers)
        {
            if (blocker.GetComponent<Blocker>())
                blocker.GetComponent<Blocker>().enabled = true;

            if (blocker.GetComponent<Reciever>())
                blocker.GetComponent<Reciever>().go = true;
        }
        foreach (GameObject defender in defenders)
        {

            if (defender.GetComponent<zonedefender>())
            {
                defender.GetComponent<zonedefender>().enabled = true;
                defender.GetComponent<Collider>().enabled = true;
            }
            if (defender.GetComponent<CornerBack>())
            {
                defender.GetComponent<CornerBack>().enabled = true;
            }
            if (defender.GetComponent<TackleBallCarrier>())
            {
                defender.GetComponent<TackleBallCarrier>().enabled = true;
            }
        }
        aiactive = true;

    }
    // Update is called once per frame
    public void Update()
    {
        if (GameObject.Find("Budgettext"))
        {
            BudgetUI = GameObject.Find("Budgettext").GetComponent<BudgetCalculator>().budget;
        }
        if  (!EventSystem.current.IsPointerOverGameObject(-1))
            {
            
            if (Input.GetKeyDown(KeyCode.Mouse0)  && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500,1, QueryTriggerInteraction.Ignore))
            {

                if (hit.collider.gameObject.tag == "placeable" && canplace == true && BudgetUI > unitcost)
                {
                    GameObject newblock = Instantiate(Blockerpicked);
                    newblock.transform.position = hit.point;
                    BudgetUI -= unitcost;
                    GameObject.Find("Budgettext").GetComponent<BudgetCalculator>().budget = BudgetUI;
                    blockers.Add(newblock);
                    if (Blockerpicked == reciever)
                    {
                        numrec++;
                        //newblock.GetComponentInChildren<Text>().text = numrec.ToString();
                    }
                }
                if (hit.collider.gameObject.tag == "Dfense")
                {
                    foreach (GameObject blocker in targblockers)
                    {
                        blocker.GetComponent<Blocker>().roamblocking = false;
                        blocker.GetComponent<Blocker>().destination = hit.transform.gameObject;


                        GameObject myLine = new GameObject();
                        myLine.transform.position = blocker.transform.position;
                        myLine.AddComponent<LineRenderer>();
                        LineRenderer lr = myLine.GetComponent<LineRenderer>();
                        lr.material = line;
                        lr.startColor = Color.blue;
                        lr.startWidth = (0.1f);
                        lr.SetPosition(0, blocker.transform.position);
                        lr.SetPosition(1, hit.transform.position);
                        blocker.transform.GetChild(1).GetComponent<MeshRenderer>().material = statik;
                    }
                    targblockers.Clear();
                }
                if ( drawroute == true)
                {
                    LineRenderer lrr;
                    List<Vector3> route = rec.GetComponent<Reciever>().route;
                    route.Add(new Vector3(hit.point.x,hit.point.y+.5f,hit.point.z));



                    if (route.Count >= 0)
                    {



                        rec.GetComponent<Reciever>().hasroute = true;
                        //GameObject myLine = new GameObject();

                        if (route.Count == 1)
                        {
                            GameObject myLine = new GameObject();
                            myLine.transform.position = rec.transform.position;
                            myLine.AddComponent<LineRenderer>();
                            lrr = myLine.GetComponent<LineRenderer>();


                            lrr.material = line;
                            lrr.startColor = Color.blue;
                            lrr.startWidth = (0.1f);
                            lrr.positionCount = 2;
                            lrr.SetPosition(0, rec.transform.position);
                            lrr.SetPosition(1, route[route.Count - 1]);
                        }

                        if (route.Count == 2)
                        {
                            GameObject myLine = new GameObject();
                          
                          
                            myLine.transform.position = rec.transform.position;
                            myLine.AddComponent<LineRenderer>();
                            lrr = myLine.GetComponent<LineRenderer>();
                            //lrr.positionCount = i;
                            lrr.material = line;
                            lrr.startColor = Color.blue;
                            lrr.startWidth = (0.1f);
                            lrr.positionCount = 2;
                            
                            lrr.SetPosition(0, route[0]);
                            lrr.SetPosition(1, route[1]);

                        }
                        if (route.Count > 2)
                        {
                            GameObject myLine = new GameObject();

                            int i = route.Count;
                            myLine.transform.position = rec.transform.position;
                            myLine.AddComponent<LineRenderer>();
                            lrr = myLine.GetComponent<LineRenderer>();
                            
                            lrr.material = line;
                            lrr.startColor = Color.blue;
                            lrr.startWidth = (0.1f);
                            lrr.positionCount = 2;

                            lrr.SetPosition(0, route[i-2]);
                            lrr.SetPosition(1, route[i-1]);

                        }
                    }

                        //rec.GetComponent<MeshRenderer>().material = statik;
                    
                  
                }
            }
            if (Input.GetKeyDown(KeyCode.Return) && drawroute == true)
            {
                rec.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material = statik;
                drawroute = false;
                canplace = true;
                //routespots = rec.GetComponent<Reciever>().route;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500, 1, QueryTriggerInteraction.Ignore))   
        {
            SelectUnit();
           
        }

        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Return) && aiactive == false) 
        {
            StartPlay();
          
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
        if (aiactive == true)
        {
            Throwball.SetActive(true);
        }
    }
}
