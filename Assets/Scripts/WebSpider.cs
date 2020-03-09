using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpider : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _forceweb = 100;
    private AudioSource _audioSource;
    void Start()
    {

        _audioSource = GetComponent<AudioSource>();


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("коллизия");
            Rigidbody2D r = collision.gameObject.GetComponent<Rigidbody2D>();
            r.gameObject.GetComponent<HeroControl>().HurtHero(_damage);
            Debug.Log("Урон");
            Vector3 delta = r.transform.position / 2 - transform.position;
            Vector3 force = delta.normalized * _forceweb;
            r.AddForce(force, ForceMode2D.Force);
            Debug.Log("addforce");
            _audioSource.Play(1);
        }
        else return;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("коллизия");
            Rigidbody2D r = collision.gameObject.GetComponent<Rigidbody2D>();
            r.gameObject.GetComponent<HeroControl>().HurtHero(_damage);
        }
    }
}