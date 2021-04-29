using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour{

    public Transform firePoint;
    public GameObject bulletPre;
    public float bulletRn;
    // public float bulletSpeed = 5;
    bool grabbed = false;
    public Animator animator;
    
    public float startShotTime;
    private float timeBtwShots = 0;

    public int magazineSize;
    public float reloadTime;
    private int bulletInMagazine;

    public int bulletSpeed;
    
    void Start(){
        
        bulletInMagazine = magazineSize;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButton("Fire1")){

            shoot();
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
        
        if(grabbed){
            if(timeBtwShots <= 0){
                if(bulletInMagazine > 0){

                    Instantiate(bulletPre, firePoint.position, firePoint.rotation * Quaternion.Euler( new Vector3(0f, 0f, Random.Range(bulletRn, -bulletRn))));
                    bulletInMagazine--;

                    timeBtwShots = startShotTime;
                }
            }else{

                Debug.Log("sgoot");
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    void reload(){

        bulletInMagazine = magazineSize;
    }
}
