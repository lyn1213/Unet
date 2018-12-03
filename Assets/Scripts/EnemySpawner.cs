using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

    public GameObject enemyPrefab;
    public int numberOfEnemise;

    public override void OnStartServer()//在server启动的时候
    {
        for (int i = 0; i < numberOfEnemise; i++)
        {
            Vector3 position = new Vector3(Random.Range(-6f, 6f), 0, Random.Range(-6f, 6f));

            Quaternion rotation =  Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            GameObject enemy = Instantiate(enemyPrefab, position, rotation)as GameObject;

            NetworkServer.Spawn(enemy);
            
        }  
    }

}
