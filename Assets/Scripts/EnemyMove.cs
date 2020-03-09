using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform Target { get => target; set => target = value; }
    public int speed;
    private int _dir;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _dir = 1;
    }

    private void FixedUpdate()
    {
        

        if (_dir == 1 && (transform.position.x - target.position.x) < 0)
        {
            _dir = -1;
            spriteRenderer.flipX = true;
            return;
        }
        if (_dir == -1 && (transform.position.x - target.position.x) >0)
        {
            _dir = 1;
            spriteRenderer.flipX = false;
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed); 
    }
   
}


