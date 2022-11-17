using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remote : MonoBehaviour {
    private Canvas CanvasObject; // Assign in inspector
    
    [SerializeField]
    private GameObject ControlObject;
    
    public float DistanceToView = 2f;
    public Transform PlayerObject;

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

        if (Input.GetKeyUp(KeyCode.E)&&(Vector3.Distance(PlayerObject.position, ControlObject.transform.position) <= DistanceToView)){
            audioPlay = !audioPlay;
            CanvasObject.enabled = !CanvasObject.enabled;
            Audio.Play();
        }
        
    }
}
