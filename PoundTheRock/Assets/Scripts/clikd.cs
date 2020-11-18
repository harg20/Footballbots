using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clikd : MonoBehaviour
{
    public GameObject Gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = GameObject.FindGameObjectWithTag("manager");
            Button btn = gameObject.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
  
    }
    void TaskOnClick()
    {

        Gamemanager.GetComponent<GameManager>().UIClick(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
