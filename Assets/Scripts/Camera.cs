using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _leftposition;
    [SerializeField] private Vector3 _rightposition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > _leftposition.x && transform.position.x < _rightposition.x)
        Move();

     
        if (transform.position.x <= _leftposition.x)
        {
           
            transform.position = (new Vector3(_leftposition.x, _player.transform.position.y, -39));
            
        }
        if (transform.position.x >= _rightposition.x) 
        {
           
            transform.position = (new Vector3(_rightposition.x, _player.transform.position.y, -39));
        }
        
        if ((transform.position.x <= _leftposition.x  && _player.transform.position.x >= -1.711767 )|| (transform.position.x >= _rightposition.x && _player.transform.position.x <= 46.03698))
        {
            Move(); 
        }


    }
    private void Move()
    {
        transform.position = (new Vector3(_player.transform.position.x, _player.transform.position.y, -39));
    }
}
