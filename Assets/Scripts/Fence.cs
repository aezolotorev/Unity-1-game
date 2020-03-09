using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _forceFence = 20;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("коллизия");
            Rigidbody2D r = collision.gameObject.GetComponent<Rigidbody2D>();
            r.gameObject.GetComponent<HeroControl>().HurtHero(_damage);
            Debug.Log("Урон");
            
            r.AddForce(new Vector3(0,90,0)* _forceFence, ForceMode2D.Force);
            Debug.Log("addforce");
            
        }
        else return;
    }

}
