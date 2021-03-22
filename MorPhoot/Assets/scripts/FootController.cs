using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    public Transform ownerAttatchmentPoint;
    BoxCollider2D boxCollider2D;
    public float speedIncreas;
    PlayerController statsToIncrease;
    private bool isStatsUpdated = false;

    private void Start() {
        
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void upadateStats(){


        statsToIncrease = GetComponentInParent<PlayerController>();
        statsToIncrease.speed *= 2;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        transform.SetParent(ownerAttatchmentPoint);

        upadateStats();
        GameObject.Destroy(gameObject);
        Debug.Log("its going all wrong!");
    }
}
