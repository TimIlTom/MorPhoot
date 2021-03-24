using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour
{
    public int healt;
    
    void Update(){
        
        //player life
        if(healt <= 0){

            die();
        }
    }

    public void takeDamage(int damage){

        this.healt -= damage;
    }

    public void die(){

        transform.position = new Vector3(-10, 0, 0);
        healt = 10;
    }
}
