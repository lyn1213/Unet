using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Health : NetworkBehaviour {

    public const int maxHealth =100;
    [SyncVar(hook ="OnChangeHealth")]//同步变量
    public int currentHealth=maxHealth;
    public Slider healthSlider;
    public bool destoryOnDeath = false;

    private NetworkStartPosition[] spawnPoints;

    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
      
    }


    public void TakeDamage(int damage)
    {
        if (isServer == false) return; //表示血量的减少只在服务器端进行

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (destoryOnDeath)
            {
                Destroy(this.gameObject);
                return;
              
            }
            currentHealth = maxHealth;
            Debug.Log("Dead");
            RpcReSpawn();
        }

       
    }

    void OnChangeHealth(int health)
    {
        healthSlider.value = health / (float)maxHealth;
    }

    [ClientRpc]
    void RpcReSpawn()
    {
        if (isLocalPlayer == false) return;

        Vector3 spawnPosition = Vector3.zero;

        if(spawnPoints!=null&&spawnPoints.Length>0)
        spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;

        transform.position = spawnPosition;
    }


}
