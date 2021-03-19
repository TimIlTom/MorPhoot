using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D bulletRb;
    public int damage = 10;
    Transform bulletTr;

    private void Start() {
        
        bulletRb = GetComponent<Rigidbody2D>();
        bulletTr = GetComponent<Transform>();
        bulletRb.AddForce(bulletTr.right * 15, ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag != "weapon001" && other.gameObject.tag != "bullet" && other.gameObject.tag != "triggerArea" && other.gameObject.tag != "Player"){

            GameObject.Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "enemy"){

            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.takeDamage(damage);
        }
    }
}
