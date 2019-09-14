using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    [HideInInspector]
    public const float maxSpeed = 0.15f;
    [HideInInspector]
    public bool moveable = true;
    public GameObject exclam;
    
    private Rigidbody2D rb2D;
    private Animator animator;
    private Vector2 velocity;
    private bool facingRight = true;
    private AnimatorStateInfo animatorStateinfo;
    private const int Gravity = 500;
    private const float JumpHeight = 30.0f;
    public static CharacterController instance = null;
    
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
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        velocity = Vector2.right;
    }

    void FixedUpdate()
    {
        if (ChapterTransition.isOver)
        {
            if (moveable)
            {
                float horizontal = Input.GetAxis("Horizontal");
                if (horizontal != 0)
                {
                    velocity.x = maxSpeed * horizontal;
                    transform.Translate(velocity);
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
            animator.Play("Jump");
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
