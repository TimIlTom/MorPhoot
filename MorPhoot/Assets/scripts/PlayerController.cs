using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;

    private bool isJumping = false;
    public Animator animator;
    Rigidbody2D playerRb;
    private Vector2 mousePos;
    public new Camera camera;
    public float angle;
    private float jumpTime;
    public float jumpTime1;
    public Transform footPosition;
    public LayerMask groundLayerMask;

    private float dashTime;
    public float dashDuration = 0.1f;
    public bool dashed = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        jumpTime = jumpTime1;
        dashTime = dashDuration;
    }

    void Update()
    {

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - playerRb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        float horozonatalMove = Input.GetAxis("Horizontal");

        //palyer rotation
        if(angle >= 90 || angle <= -90){

            transform.rotation =  Quaternion.Euler(0f, 180f, 0f);
        }else if(angle <= 90 && angle >= -90){
            
            transform.rotation =  Quaternion.Euler(0f, 0, 0f);
        }

        animator.SetFloat("speed", Mathf.Abs(horozonatalMove));

        //player movement
        Vector2 movement = new Vector2(horozonatalMove * speed, playerRb.velocity.y);
        playerRb.velocity = movement;

        if(Input.GetButtonDown("Fire2")){

            dashed = true;
        }
        if(dashed){

            if(dashTime > 0){

                Debug.Log("hello");
                playerRb.velocity = new Vector2(horozonatalMove * 50, playerRb.velocity.y) ;
                dashTime -= Time.deltaTime;
            }else{

                dashTime = dashDuration;
                dashed = false;
            }
        }
        jump();
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        
        Debug.Log("Ground");
        animator.SetBool("isJumping", false);
    }

    private void jump(){
        
        bool isGrounded = Physics2D.OverlapCircle(footPosition.position, 0.3f, groundLayerMask);

        if(isGrounded && Input.GetButtonDown("Jump")){
            
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
            isJumping = true;
            jumpTime = jumpTime1;
            Debug.Log("Ilove ground!");
        }

        if(/*Input.GetButton("Jump") &&*/ isJumping){

            if(jumpTime > 0){

                jumpTime -= Time.deltaTime;
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
                animator.SetBool("isJumping", true);
            } else if(jumpTime <= 0){

                isJumping = false;
            }
        }

        if(Input.GetButtonUp("Jump")){
            
            isJumping = false;
        }
    }
}
