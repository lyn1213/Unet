using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public enum ShootModel
{
    Single,Trible,AutoFire
}
public class Player : MonoBehaviour {

    public static Player instance;
    #region Shoot
    private float timer;  //射击计时器       
    private GameObject gun;
    public ShootModel currentModle=ShootModel.Single;
    #endregion   
    #region  Move
    [SerializeField]
    private float acceleration;
    public float maxSpeed;
    private float currenSpeed;
    public Transform headTransform; //视角正方向

    #endregion
    private bool padClick;
    public bool canShoot; //可以射击

    float horizontalMove;
    // Use this for initialization
    void Awake () {
        instance = this;
        Init();
    }
	public void Init()
    {
        canShoot = false;
        transform.position = Vector3.zero;
        //if(gun)
        //gun.GetComponent<Gun>().Init();
    }
    // Update is called once per frame
    void Update() {

    #region 移动
        timer += Time.deltaTime;
        CalculateSpeed();

        transform.position += currenSpeed *new Vector3(headTransform.forward.x, 0, headTransform.forward.z)
             * Time.deltaTime ;
        transform.position += HorizontalMove();
    }
    public void OnPadClick(bool buttonState)
    {
        padClick = buttonState;
    }
    public void Move(Vector2 axis)
    {
        //Debug.Log("axis:  "+ axis+ "   "+ padClick);
        if (padClick)
        {
            acceleration = axis.y;
            horizontalMove = axis.x;
        }           
        else
        {
            //Debug.Log("acceleration =0");
            acceleration = 0;
            horizontalMove = 0;
        }
    }
    private Vector3 HorizontalMove()
    {
        if (horizontalMove != 0)
        {
            //Debug.Log(new Vector3(headTransform.right.x, 0, 0));

            return new Vector3(headTransform.right.x, 0, headTransform.right.z) *horizontalMove * Time.deltaTime*1.5f;
        }
        else
        {
            return Vector3.zero;
        }
    }
    private void CalculateSpeed()
    {
        if (acceleration != 0)
        {
            //Debug.Log("currenSpeed :  " + currenSpeed + "acceleration:  "+ acceleration);
            currenSpeed = Mathf.Clamp((currenSpeed+ 0.05f + acceleration), -maxSpeed, maxSpeed);          
        }
        else
        {
            if (padClick)
            {
                return;
            }
            else
            {
                currenSpeed = 0;
                //Decelerate();
            }
        }
    }

    private void Decelerate()
    {
        if (currenSpeed != 0)
        {
            currenSpeed -= Mathf.Lerp(0, currenSpeed, Time.deltaTime);
        }
        //else if (currenSpeed < 0)
        //{
        //    currenSpeed += Mathf.Lerp(0, -currenSpeed, Time.deltaTime*5);
        //}
        else
        {
            currenSpeed = 0;
        }
    }
    #endregion
    /*#region 射击
    public void SetModel(ShootModel model)
    {
        currentModle = model;
    }
    public void SetGun(GameObject gun)
    {
        this.gun = gun;
    }
    public void Shoot()
    {
        if(canShoot && gun.GetComponent<Gun>().Shoot(timer,currentModle))
        {
            timer = (currentModle == ShootModel.Trible ? -gun.GetComponent<Gun>().tribleShootCD*3 : 0);
        }
    }
    public void ChangeFireModel()
    {
        currentModle =  (ShootModel)((int)currentModle + 1 >= 3 ? (int)currentModle - 2 : (int)currentModle + 1);
    }
    #endregion */
    public void OnControllerGrabChange(VRTK_ObjectAutoGrab controller, GameObject newObject)
    {
       // controller.
    }
    //public GameObject ClipObj()
    //{
    //    return gun.GetComponent<Gun>().clip;
    //}
	public AudioSource GetSource(){
 		return GetComponent<AudioSource>();
	}
}
