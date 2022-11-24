using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov2 : MonoBehaviour
{
    public CharacterController controller;
    public float speed =10f;
    public GameObject Camara;
    public GameObject cilindro;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);

        Vector3 newRotation = new Vector3(0, Camara.transform.eulerAngles.y, Camara.transform.eulerAngles.z);
        cilindro.transform.eulerAngles = newRotation;
    }
}
