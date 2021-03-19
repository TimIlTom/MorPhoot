using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;
    public int healt;
    private bool isJumped = false;
    public Animator animator;
    Rigidbody2D playerRb;
    private Vector2 mousePos;
    public new Camera camera;
    public float angle;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
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

        if(Input.GetButtonDown ("Jump") && isJumped == false){

            isJumped = true;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
            animator.SetBool("isJumping", true);
        }

        //player life
        if(healt <= 0){

            die();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "ground"){

            isJumped = false;
            animator.SetBool("isJumping", false);
        }
    }

    public void takeDamage(int damage){

        this.healt -= damage;
    }

    public void die(){

        transform.position = new Vector3(-10, 0, 0);
        healt = 100;
    }
}
