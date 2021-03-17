using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int healtAmount;
    public int damage;
    public GameObject enemyTriggerArea;

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

            attack(player.transform.position);
        }
    }

    private void attack(Vector3 playerPos){

        if(transform.position.x != playerPos.x){

            transform.position += new Vector3(-0.1f, 0, 0);
        }
    }
}
