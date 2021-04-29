using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D bulletRb;
    public int damage = 10;
    public int bulletSpeed;

    private void Start() {
        
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag != "weapon001" && other.gameObject.tag != "bullet" && other.gameObject.tag != "triggerArea"){

            GameObject.Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "enemy"){

            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.takeDamage(damage);
        }
    }
}
