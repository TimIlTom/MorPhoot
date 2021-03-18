using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int healtAmount;
    public int damage;
    public GameObject enemyTriggerArea;
    public Transform firePoint;
    public GameObject bullet;

    public void takeDamage(int damage){

        healtAmount -= damage;

        if(healtAmount <= 0){

            die();
        }
    }

    void die(){

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Player"){

            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            player.takeDamage(damage);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player"){

            Debug.Log("ao");
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            // attack(player.transform.position);
        }
    }

    // private void attack(Vector3 playerPos){
        
    //     Vector3 lookDirection = playerPos - transform.position ;

    //     float rotatio = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

    //     firePoint.rotation = Quaternion.Euler(0f, 0f, rotatio);
    //     Instantiate(this.bullet, firePoint.position, firePoint.rotation);

    //     GameObject bullet = Instantiate(this.bullet, firePoint.position, firePoint.rotation);
    //     Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

    //     bulletRb.AddForce(firePoint.right * 5, ForceMode2D.Impulse);
    // }
}
