using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform cameraSubject;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraSubject.transform.position.x, cameraSubject.transform.position.y, -9f);
        Cursor.visible = false;
    }
}
