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
    public SpriteRenderer spriteRenderer;
    public Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown ("Jump") && isJumped == false){

            isJumped = true;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
            animator.SetBool("isJumping", true);
            //playerRb.velocity = new Vector2
        }

        float horozonatalMove = Input.GetAxis("Horizontal");

        if(horozonatalMove < 0){

            transform.rotation =  Quaternion.Euler(0f, 180f, 0f);

            /*spriteRenderer.flipX = true;
            hand.transform.rotation = Quaternion.Euler(0f, 180f, 0f);*/
        }else if(horozonatalMove > 0){
            
            transform.rotation =  Quaternion.Euler(0f, 0, 0f);
            /*hand.transform.rotation = Quaternion.Euler(0f, 0, 0f);
            spriteRenderer.flipX = false;*/
        }

        animator.SetFloat("speed", Mathf.Abs(horozonatalMove));

        Vector2 movement = new Vector2(horozonatalMove * speed, playerRb.velocity.y);

        playerRb.velocity = movement;

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
