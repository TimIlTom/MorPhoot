using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform owner;
    private bool grabbed = false;
    public Camera cam;
    private Vector2 mousePos;
    Rigidbody2D weaponRb;

    PlayerController player;

    float lastRotation = 0;

    private void Start() {
        
        weaponRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if(grabbed == true){

            transform.position = owner.transform.position;
            //transform.rotation = owner.transform.rotation;

            // Vector2 lookDir = mousePos - weaponRb.position;
            // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            float yRotation = owner.transform.rotation.y * 180f;
            
            player = GetComponentInParent<PlayerController>();
            transform.rotation = Quaternion.Euler(0f, yRotation, player.angle); 

            //code that manage the rotation of the weapon

            if(yRotation == 0){

                transform.rotation = Quaternion.Euler(0f, yRotation, lastRotation);

                if(player.angle <= 90 && player.angle >= -90){

                    transform.rotation = Quaternion.Euler(0f, yRotation, player.angle);
                    lastRotation = player.angle;
                }
            }else{

                transform.rotation = Quaternion.Euler(0f, yRotation, lastRotation);

                if(player.angle >= 90 || player.angle <= -90){

                    transform.rotation = Quaternion.Euler(0f, yRotation, 180 - player.angle);
                    lastRotation = 180 - player.angle;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        grabbed = true;
        transform.SetParent(owner);
    }
}
