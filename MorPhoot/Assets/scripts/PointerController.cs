using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class PointerController : MonoBehaviour
{   
    public new Camera camera;
    private Vector2 mousePos;
    private Rigidbody2D pointerRb;
    // Start is called before the first frame update
    void Start()
    {
        pointerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
