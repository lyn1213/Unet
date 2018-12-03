using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferTask : MonoBehaviour ,ITransfer{

    public  Text reportTransfer;
    public  Button saveBtn;
    public Button AgainBtn;


	// Use this for initialization
	void Start () {

        AcceptFile();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReportText(int a)
    {
        if (a == 1)
        {
            reportTransfer.text = "任务成功";
        }
        else {
            reportTransfer.text = "任务失败";
        }
      
    }

    public void SaveTask()
    {
        Debug.Log("保存");
    }

    public void AgainTask()
    {
        Debug.Log("重新");
    }

    public void AcceptFile()
    {
        //传输文件
        int a = 1;
        ReportText(a);
       
    }

    public void TransferFile()
    {
        throw new System.NotImplementedException();
    }
}
