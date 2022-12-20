using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckedGesture : MonoBehaviour
{
    public GameObject TV;
    private AudioSource checkSound;
    public GameObject hand;
    public Material checkMat;
    private Material origMat;

    void Start()
    {
        origMat = hand.GetComponent<SkinnedMeshRenderer>().material;
        checkSound = TV.GetComponent<AudioSource>();
        checkSound.Play();
        
        while(checkSound.isPlaying)
        {
            hand.GetComponent<SkinnedMeshRenderer>().material = checkMat;
        }
        
        hand.GetComponent<SkinnedMeshRenderer>().material = origMat;
    }
}
