using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemypumpkin : MonoBehaviour
{
    [SerializeField] private int _timepush;
    [SerializeField] private int _pushDelay;
    [SerializeField] private int _force;
    [SerializeField] private int _damage;
    [SerializeField] private int _forceattack;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Push", _pushDelay, _timepush);

    }


    void Push()
    {
         Rigidbody2D  r= GetComponent<Rigidbody2D>();
         r.AddForce(new Vector3(0,-90,0)*_force, ForceMode2D.Force);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("коллизия");
            Rigidbody2D r = collision.gameObject.GetComponent<Rigidbody2D>();
            r.gameObject.GetComponent<HeroControl>().HurtHero(_damage);
            Debug.Log("Урон");
            Vector3 delta = r.transform.position - transform.position;
            Vector3 force = delta.normalized * _forceattack;
            r.AddForce(force);


        }
        else return;
    }
}
