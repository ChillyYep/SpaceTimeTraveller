using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    [HideInInspector]
    public const float maxSpeed = 0.15f;
    [HideInInspector]
    public bool moveable = true;
    public GameObject exclam;
<<<<<<< HEAD

    //private bool isGround = true;
=======
    
>>>>>>> new
    private Rigidbody2D rb2D;
    private Animator animator;
    private Vector2 velocity;
    private bool facingRight = true;
<<<<<<< HEAD
    //private bool isJump = false;
    private AnimatorStateInfo animatorStateinfo;
    //private const int Force = 1000;
    private const int Gravity = 500;
    private const float JumpHeight = 30.0f;
    public static CharacterController instance = null;

    //private Rigidbody2D rg2D;
=======
    private AnimatorStateInfo animatorStateinfo;
    private const int Gravity = 500;
    private const float JumpHeight = 30.0f;
    public static CharacterController instance = null;
    
>>>>>>> new
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance=this)
        {
            Destroy(gameObject);
        }
        moveable = true;
        Debug.Log("Awake"+moveable);
<<<<<<< HEAD
        //DontDestroyOnLoad(gameObject);
=======
>>>>>>> new
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        velocity = Vector2.right;
    }

<<<<<<< HEAD
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (SoundController.instance != null)
    //    {
    //        SoundController.instance.PlaySoundEffect(SoundController.SoundEffect.HIT);
    //    }
    //}
=======
>>>>>>> new
    void FixedUpdate()
    {
        if (ChapterTransition.isOver)
        {
            if (moveable)
            {
                float horizontal = Input.GetAxis("Horizontal");
<<<<<<< HEAD
                //transform.Translate(new Vector2(maxSpeed * horizontal, 0));
                if (horizontal != 0)
                {
                    velocity.x = maxSpeed * horizontal;
                    //velocity.y = rb2D.velocity.y;
                    transform.Translate(velocity);
                    //rb2D.velocity += velocity;
                    //rb2D.AddForce(new Vector2(maxSpeed * horizontal, 0));
                    //rg2D.MovePosition(velocity);
                    //velocity.x = 0;
=======
                if (horizontal != 0)
                {
                    velocity.x = maxSpeed * horizontal;
                    transform.Translate(velocity);
>>>>>>> new
                }

                if (horizontal > 0 && !facingRight)//向右转
                {
                    Flip();
                }
                else if (horizontal < 0 && facingRight)//向左转
                {
                    Flip();
                }
                Walk();
                Jump();
            }

        }
<<<<<<< HEAD
        //Debug.Log("rb2D.velocity:" + rb2D.velocity);
=======
>>>>>>> new
    }

    public void Flip()
    {
        Vector3 vector3 = transform.localScale;
        facingRight = !facingRight;
        vector3.x = -vector3.x;
        transform.localScale = vector3;
    }

    void Walk()
    {
        if (Input.GetAxis("Horizontal")!=0f )
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&& rb2D.velocity.y==0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, JumpHeight);
<<<<<<< HEAD
            //rb2D.AddForce(Vector2.up * JumpHeight);
            animator.Play("Jump");
            //isJump = true;
=======
            animator.Play("Jump");
>>>>>>> new
        }
    }

    public void StopWalkAnim()
    {
        animator.SetBool("Walk", false);
    }

    public void StartWalkAnim()
    {
        animator.SetBool("Walk", true);
    }

    public void ShowExclam()
    {
        //音乐
        if (SoundController.instance != null)
        {
            SoundController.instance.PlaySoundEffect(SoundController.SoundEffect.SHOCK);
        }
        exclam.SetActive(true);
    }

    public void HideExclam()
    {
        exclam.SetActive(false);
    }
}
