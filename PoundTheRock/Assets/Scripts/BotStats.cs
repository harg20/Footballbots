using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BotStats : MonoBehaviour
{
    public int speed;
    public int strength;
    public int cost;
    public string[] Upgrades;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Upgrade(string upg)
    {
        switch (upg) {

            case "Speed":
                speed += 1;
                cost += 10;
                if (GetComponent<carrier>())
                {
                    GetComponent<carrier>().speed *= 1.1f;
                }
                if (GetComponent<NavMeshAgent>())
                {
                    GetComponent<NavMeshAgent>().speed *= 1.1f;
                }

                
                return;


        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
