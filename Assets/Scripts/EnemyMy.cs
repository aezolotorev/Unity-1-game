using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMy : MonoBehaviour
{
    [SerializeField]   private int _hp;
    [SerializeField] private int _forceattack;
    [SerializeField] private int _damage;
    // Start is called before the first frame update
    void Start()
    {
        _hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hurt(int Damage)
    {
        _hp -= Damage;
        if (_hp == 0)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("коллизия");
            Rigidbody2D r = collision.gameObject.GetComponent<Rigidbody2D>();
            r.gameObject.GetComponent<HeroControl>().HurtHero(_damage);
            Debug.Log("Урон");
            Vector3 delta = r.transform.position- transform.position;
            Vector3 force = delta.normalized * _forceattack;
            r.AddForce(force, ForceMode2D.Impulse);
            Debug.Log("addforce");
            

        }
        else return;
    }

}
