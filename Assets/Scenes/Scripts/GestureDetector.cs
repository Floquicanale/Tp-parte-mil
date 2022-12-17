using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{

    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones;
    
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
    }


    void Update()
    {
        
    }
}
