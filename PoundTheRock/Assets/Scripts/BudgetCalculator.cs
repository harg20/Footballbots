using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BudgetCalculator : MonoBehaviour
{
    public int budget = 0;
    Text budgetxt ;
    // Start is called before the first frame update
    void Start()
    {
        
        foreach(GameObject defender in GameObject.FindGameObjectsWithTag("Dfense"))
        {
            
                budget += defender.GetComponent<BotStats>().cost;
            
           
        }
       budgetxt = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        budgetxt.text = "Budget: " + budget.ToString();
    }
}
