using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    public float speed = 5;
   
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private Transform _startBullet;
    [SerializeField] private Transform _startbomb;
    [SerializeField] private float _forcejump;
    [SerializeField] private float _forcemove;
    [SerializeField] private int _maxSpeed;
    private ActionButtons button;
    public ActionButtons Button { get => button; set => button = value; }
    public bool ActiveMenu = false;
    private Animator _animator;
    private AudioSource _audioSource;
    private int _hp;
    private Rigidbody2D rb;
    private Vector3 startposition;
    private Transform groundCheck;
    private bool grounded = false;
    private bool jump;
    SpriteRenderer spriteRenderer;
    public int dir=1;
    [SerializeField] private AudioClip _heroangry;
    [SerializeField] private AudioClip _step;
    // Start is called before the first frame update
    private void Awake()
    {
        _hp = 100;
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundCheck = transform.Find("GroundCheck");
        rb = GetComponent<Rigidbody2D>();
        startposition = transform.position;
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _animator.SetBool("IsAlive", true);
        Button = ActionButtons.NotPressed;
    }
    public void Buttons()
    {
        switch ((int)Button)
        {
            case (int)ActionButtons.LeftMove:
                {
                    LeftMove();
                }
                break;
            case (int)ActionButtons.RightMove:
                {
                    RightMove();
                }
                break;
            default:
                Button = ActionButtons.NotPressed;
                break;
        }
    }
 


    public void ReStart()
    {
        transform.position = startposition;
        _hp = 100;
        _animator.SetBool("IsAlive", true);
    }

    // Update is called once per frame
 
   public void RightMove()
    {
        if (dir == -1)
        {
            spriteRenderer.flipX = false;
            dir = 1;
            _startBullet.localPosition = new Vector3(_startBullet.localPosition.x * (-1), _startBullet.localPosition.y, 0);
            _startbomb.localPosition = new Vector3(_startbomb.localPosition.x * (-1), _startbomb.localPosition.y, 0);
        }
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * _forcemove, ForceMode2D.Impulse);
        _animator.SetBool("IsRun", true);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > _maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
    public void LeftMove()
    {
        if (dir == 1)
        {
            spriteRenderer.flipX = true;
            dir = -1;
            _startBullet.localPosition = new Vector3(_startBullet.localPosition.x * (-1), _startBullet.localPosition.y, 0);
            _startbomb.localPosition = new Vector3(_startbomb.localPosition.x * (-1), _startbomb.localPosition.y, 0);
        }
        GetComponent<Rigidbody2D>().AddForce(Vector3.left * _forcemove, ForceMode2D.Impulse);
        _animator.SetBool("IsRun", true);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > _maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
    public void Jump()
    {
        if (grounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * _forcejump, ForceMode2D.Impulse);
            _animator.SetBool("IsJump", true);
        }
    }

    public void FixedUpdate()
    {
        Buttons();
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (grounded == true)
        {
            _animator.SetBool("IsJump", false);
        }
        if (rb.velocity.x == 0)
        {
            _animator.SetBool("IsRun", false);
        }
        else
        {
            _animator.SetBool("IsAlive", true);
            _animator.SetBool("IsAttack", false);
        }




        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RightMove();
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            LeftMove();
        }

        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }

        else if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Bomb();
        }

    }
        public void StopAttack()
        {
        _animator.SetBool("IsAttack", false);
        }

       public void Fire()
        {
             _animator.SetBool("IsAttack", true);
            var bullet =new  BulletFly();
            if (dir==1)
                bullet= Instantiate(_bullet, _startBullet.position, Quaternion.identity).GetComponent<BulletFly>();
            else
                bullet=Instantiate(_bullet, _startBullet.position, Quaternion.Euler(new Vector3(0,180,0))).GetComponent<BulletFly>();
             Invoke("StopAttack", 0.1f);

         }
     public void Bomb()
        {
            var bomb = new Bomb();
        
                bomb = Instantiate(_bomb, _startbomb.position, Quaternion.identity).GetComponent<Bomb>();
                bomb.GetComponent<Bomb>().Init(dir);
            Invoke("StopAttack", 0.1f);
        }
        public int GetHP()
        {
            return _hp;
        }

    public void HurtHero(int damage)
    {
        _audioSource.PlayOneShot(_heroangry);
        _hp -= damage;
        
        if (_hp <= 0)
        {
            _animator.SetBool("IsAlive", false);
            ReStart();
            
        }
    }
    public void Step()
    {
        _audioSource.PlayOneShot(_step);
    }
   

}
