using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remote : MonoBehaviour {
    private Canvas CanvasObject; // Assign in inspector
 
    void Start()
    {
        CanvasObject = GetComponent<Canvas> ();
    }
 
    void Update() 
    {
        if (Input.GetKeyUp(KeyCode.Escape)){
           CanvasObject.enabled = !CanvasObject.enabled;
        }
    }
}
