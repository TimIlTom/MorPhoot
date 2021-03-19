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

    float lastRotation = 0;

    private void Start() {
        
        weaponRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if(grabbed == true){

            transform.position = owner.transform.position;
            transform.rotation = owner.transform.rotation;

            Vector2 lookDir = mousePos - weaponRb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            float yRotation = owner.transform.rotation.y * 180f;
            
        
            transform.SetParent(owner);

            //code that manage the rotatio of the weapon
            if(yRotation == 0){

                transform.rotation = Quaternion.Euler(0f, yRotation, lastRotation);

                if(angle <= 90 && angle >= -90){

                    transform.rotation = Quaternion.Euler(0f, yRotation, angle);
                    lastRotation = angle;
                }
            }else{

                transform.rotation = Quaternion.Euler(0f, yRotation, lastRotation);

                if(angle >= 90 && angle <= 180 || angle <= -90 && angle >= -180){

                    transform.rotation = Quaternion.Euler(0f, yRotation, 180 - angle);
                    lastRotation = 180 - angle;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        grabbed = true;
    }
}
