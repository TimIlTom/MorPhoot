using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingGun : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private Vector2 graplePoint;
    public LayerMask whatCanIGrap;
    private SpringJoint2D joint2D;
    public Transform firePoint, player;
    public float maxDistance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update(){
        if(gameObject.GetComponent<WeaponController>().grabbed == true){

            if(Input.GetButtonDown("Fire1")){

            Debug.Log("graplee");
            startGraple();
            }else if (Input.GetButtonUp("Fire1")){

                Debug.Log("stop graplee");
                stopGraple();
            }
        }
        
    }

    void startGraple(){

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, maxDistance, whatCanIGrap);
        player.GetComponent<PlayerController>().enabled = false;

        if(hit){

            graplePoint = hit.point;
            joint2D = player.gameObject.AddComponent<SpringJoint2D>();
            joint2D.autoConfigureConnectedAnchor = false;
            joint2D.connectedAnchor = graplePoint;
            // joint2D.anchor = firePoint.position;

            joint2D.autoConfigureDistance = false;
            // joint2D.distance /= 2;
            // joint2D.frequency = 1.5f;
            joint2D.distance *= 0.8f;
            Debug.Log(hit.point);

            // float distanceFromPoint = Vector2.Distance(player.position, graplePoint);
        }
    }

    void stopGraple(){

        player.GetComponent<PlayerController>().enabled = true;
        Destroy(joint2D);
    }
}
