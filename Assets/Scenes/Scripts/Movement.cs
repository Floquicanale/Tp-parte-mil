using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Camara;
    public float mouseSensitivity = 100f;
    // Update is called once per frame
    void Update()
    {
        Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), 1.60f, Input.GetAxis("Mouse Y"));
        Camara.transform.position = NewPosition;
    }
}
