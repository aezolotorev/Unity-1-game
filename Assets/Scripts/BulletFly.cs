using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{

    private int _damage = 50;
    private float _speed = 5;
    private float _lifeTime = 3;
    private AudioSource _audioSource;
    private int i;
    [SerializeField] private AudioClip[] _bulletfly;

    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _audioSource.PlayOneShot(_bulletfly[Random.Range(0, _bulletfly.Length)]);
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        transform.Translate(new Vector3(Time.deltaTime * _speed, 0, 0));

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyMy>().Hurt(_damage);

            Destroy(gameObject);

        }
    }
} 