using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask WhatIsGround;
    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer sr;
    public float bounceForce;
    Vector3 mouse;
    Vector3 PlayerScreenPoint;
    public Transform Player;
    


   

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bounceForce);
    }
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;

        
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = collision.transform;
        }
         if(collision.gameObject.tag == "finish")
        {
            
            int currentLevel= SceneManager.GetActiveScene().buildIndex;
            if (currentLevel >= PlayerPrefs.GetInt("levelLock"))
            {
                Debug.Log("töötabFinish");
                PlayerPrefs.SetInt("LevelLock", currentLevel + 1);
                SceneManager.LoadScene(currentLevel + 1);
              //  levelManager.instance.EndLevel();


            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = null;
        }
    }


    public void OnMouseDown()
    {
        
            mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            PlayerScreenPoint = Camera.main.WorldToScreenPoint(Player.position);
            Debug.Log("hästi");
            if (mouse.x > PlayerScreenPoint.x)
            {
                anim.SetTrigger("shoot");
                sr.flipX = true;
            }
            else
            {
                anim.SetTrigger("shoot");
                sr.flipX = false;
            }
    }   



    // Update is called once per frame
    void Update()
    {

       
       // Debug.Log(mouse);
        if (rb.velocity.x < -0.01)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0.01)
        {
            sr.flipX = false;
        }

        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, WhatIsGround);
        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (isGrounded)
        {
            canDoubleJump = true;
        }




        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                SoundManagerScript.instance.PlaySound(10);
            }


            else
            {
                if (canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canDoubleJump = false;
                    SoundManagerScript.instance.PlaySound(10);
                }

            }
        }
    }
}