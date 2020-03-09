using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    [SerializeField] private int _forcebomb;
    [SerializeField] private int _force;
    [SerializeField] private int _damage;
    public float _timedetonate;
    [SerializeField] private int bombRadius;
    [SerializeField] private int bombdistanceboom;
    public GameObject explosion;
    //public Transform enemyforbomb;
    //public Transform Enemyforbomb { get => enemyforbomb; set => enemyforbomb = value; }

    public int dir;

   
    public void Init(int dir)
    {
       
           GetComponent<Rigidbody2D>().AddForce(Vector2.right * _force*dir, ForceMode2D.Impulse);
           StartCoroutine(BombBoom());
          

    }
    IEnumerator BombBoom()
    {
        yield return new WaitForSeconds(_timedetonate);
        
        Boom();     
    }
    
    public void Boom()
    {
        //if (Vector2.Distance(transform.position, enemyforbomb.transform.position) < bombdistanceboom)
        {
            
            Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Enemy"));
            foreach (Collider2D i in enemys)
            {
                Rigidbody2D r = i.GetComponent<Rigidbody2D>();
                if (i != null && r.tag == "Enemy")
                {
                    r.gameObject.GetComponent<EnemyMy>().Hurt(_damage);
                    Vector3 delta = r.transform.position - transform.position;
                    Vector3 force = delta.normalized * _forcebomb;
                    r.AddForce(force);
                }
            }
            
            Destroy(gameObject);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            Instantiate(explosion, transform.position, randomRotation);
        }
    }


    void Update()
    {
        
       
    }
}
