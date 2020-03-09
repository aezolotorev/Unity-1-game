using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 _leftposition;
    [SerializeField] private Vector3 _rightposition;
    [SerializeField] private Transform _hero;
    [SerializeField] private int _speed;
    [SerializeField] private int _distancetohero;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startBullet;
    SpriteRenderer spriteRenderer;
    private float _mindistance = 0.1F;
    private int _dir;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _dir = 1;
    }
  
          

    void Update()
    {
        if (Vector3.Distance(_hero.position, transform.position) > _distancetohero)
        {
            if (_dir == 1 && Mathf.Abs(transform.position.x - _rightposition.x) < _mindistance)
            {
                _dir = -1;
                spriteRenderer.flipX = true;
                return;
            }
            if (_dir == -1 && (Mathf.Abs(transform.position.x - _leftposition.x) <= _mindistance))
            {
                _dir = 1;
                spriteRenderer.flipX = false;
                return;
            }
            if (_dir == 1 && (transform.position.x < _rightposition.x))
                transform.Translate(new Vector2(Time.deltaTime * _speed * _dir, 0));
            else if (_dir == -1 && (transform.position.x > _leftposition.x))
                transform.Translate(new Vector2(Time.deltaTime * _speed * _dir, 0));
        }
        else
        {
            if (_dir == 1 && transform.position.x > _hero.position.x)
            {
                _dir = -1;
                spriteRenderer.flipX = true;
                
            }
            else if (_dir == -1 && transform.position.x < _hero.position.x)
            {
                _dir = 1;
                spriteRenderer.flipX = false;
               
            }
            if (_dir == 1 && (transform.position.x < _rightposition.x))
                transform.Translate(new Vector2(Time.deltaTime * _speed * _dir, 0));
            else if (_dir == -1 && (transform.position.x > _leftposition.x))
                transform.Translate(new Vector2(Time.deltaTime * _speed * _dir, 0));
        }
    }


}