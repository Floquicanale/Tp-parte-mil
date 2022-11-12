using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remote : MonoBehaviour {
    private Canvas CanvasObject; // Assign in inspector

    [SerializeField]
    private AudioSource Audio;
    bool audioPlay = false;

    void Start()
    {
        CanvasObject = GetComponent<Canvas> ();
        CanvasObject.enabled = false;
        Audio = GetComponentInChildren<AudioSource>();
    }
 
    void Update() 
    {
        if (!audioPlay){
            Audio.Pause();
        }

        if (Input.GetKeyUp(KeyCode.E)){
            audioPlay = !audioPlay;
           CanvasObject.enabled = !CanvasObject.enabled;
           Audio.Play();
        }
        
    }
}
