using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObjToList : MonoBehaviour
{
    public GameObject itemtemplate;
    public GameObject content;
    public GameObject[] bots;
    
    
    // Start is called before the first frame update
 
    public void Start()
    {
       
       //bots = GameObject.FindGameObjectsWithTag("bot");
        foreach (GameObject bot in bots)
        {
            
            var copy = Instantiate(itemtemplate);
            copy.transform.parent = content.transform;
            copy.transform.GetChild(0).GetComponent<Text>().text = bot.name;
            copy.transform.GetChild(1).GetComponent<Text>().text = bot.GetComponent<BotStats>().cost.ToString();
        }
    }

   /* public void BotSelect(GameObject text)
    {
       GameObject selected = GameObject.Find(text.GetComponentInChildren<Text>().text);

       //gameObject.GetComponentInParent<commandcenter>().bots.Add(selected);
       selected.transform.gameObject.GetComponentInChildren<Image>().color = Color.red;
    }
    */
    // Update is called once per frame

}
