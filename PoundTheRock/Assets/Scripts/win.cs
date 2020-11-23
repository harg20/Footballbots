using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject Winmenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "carrier")
        {
            Time.timeScale = 0;
            Winmenu.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
