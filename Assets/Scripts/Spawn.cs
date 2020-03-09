using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnTime = 5f;        
    public float spawnDelay = 3f;       
    public GameObject  Enemy;
    public Transform Player;


    void Start()
    {
        
        InvokeRepeating("Spawning", spawnDelay, spawnTime);

    }


    void Spawning()
    {
        
        
        GameObject temp = Instantiate(Enemy, transform.position, transform.rotation);
        temp.GetComponent<EnemyMove>().Target=Player;
        //temp.GetComponent<Bomb>().Enemyforbomb = Enemy.transform;
    }
 
}