using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnLevel(string level) //返回难度等级
    {
        Debug.Log(level);

    }

    public void StartBtn()
    {
        Debug.Log("开始");
    }



}
