using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;


	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * h * 120 * Time.deltaTime);
        transform.Translate(Vector3.forward * v * 3 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

	}

    public override void OnStartLocalPlayer()
    {
        //这个方法只会在本地角色那里调用
          GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    [Command]//表示虽然这个脚本在client端调用的，但是是在server端运行的
    void CmdFire()//这个方法需要在server端里面调用
    {
        //需要在网络上同步处理放在server端处理，然后把子弹同步到client端
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
        Destroy(bullet, 2);

        NetworkServer.Spawn(bullet);

    }


}


