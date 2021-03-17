using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour{

    public Transform firePoint;
    public GameObject bulletPre;
    public float bulletSpeed = 5;
    bool grabbed = false;
    public Animator animator;
    public float startShotTime;
    private float timeBtwShots = 0;
    public int magazineSize;
    public float reloadTime;
    private int bulletInMagazine;
    void Start(){
        
        bulletInMagazine = magazineSize;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButton("Fire1")){

            if(grabbed){
                
                if(bulletInMagazine > 0){

                    shoot();
                }else{

                    Invoke("reload", reloadTime);
                }
                
                //StartCoroutine(shoot1());
            }
        }

        if(Input.GetKeyDown("r")){

            Invoke("reload", reloadTime);
        }
        animator.SetBool("isShooting", false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        grabbed = true;
    }

    void shoot(){

        animator.SetBool("isShooting", true);
        
        if(timeBtwShots <= 0){

            GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            bulletRb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);

            bulletInMagazine--;

            timeBtwShots = startShotTime;
        }else{

            timeBtwShots -= Time.deltaTime;
        }
        
        //bulletRb.velocity = firePoint.right * bulletSpeed;
    }

    void reload(){

        bulletInMagazine = magazineSize;
    }
}
