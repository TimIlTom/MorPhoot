using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;

    private bool isJumped = false;
    public Animator animator;
    Rigidbody2D playerRb;
    private Vector2 mousePos;
    public new Camera camera;
    public float angle;
    private float jumpTime;
    public float jumpTime1;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        jumpTime = jumpTime1;
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

        jump();
    }
    
    private void OnCollisionStay2D(Collision2D other) {
        
        Debug.Log("Ground");

        if(other.gameObject.tag == "ground"){

            isJumped = false;
            jumpTime = jumpTime1;
            animator.SetBool("isJumping", false);
        }
    }

    private void jump(){

        if(Input.GetButton("Jump") && !isJumped){

            if(jumpTime > 0){

                jumpTime -= Time.deltaTime;
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
                animator.SetBool("isJumping", true);
            }  
        }

        if(Input.GetButtonUp("Jump")){
            
            isJumped = true;
        }
    }
}
