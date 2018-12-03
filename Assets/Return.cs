using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Return : MonoBehaviour {

    public  GameObject toggleGroup;
    public List<Toggle> tog;
	// Use this for initialization
	void Start () {
       // toggleGroup.GetComponent<ToggleGroup>().ActiveToggles();

       
	}
	
	// Update is called once per frame
	void Update () {

        
       // Debug.Log(toggleGroup.GetComponent<ToggleGroup>().ActiveToggles());
       
    }
    public void ToggleName(string name)
    {
  
       // if(GetComponent<Toggle>().isOn)
        Debug.Log(name);
    }
}
