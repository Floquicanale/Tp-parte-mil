using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}

public class GestureDetector1 : MonoBehaviour
{

    public float threshold = 0.1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones;
    private Gesture previousGesture;
    public Texture video0;
    public Texture video1;
    public Texture video2;
    public Texture video3;
    public Texture video4;
    public Texture video5;
    public GameObject tele;

    IEnumerator Start(){
        private Texture textura;
        private VideoClip videosource;
        private bool loop;
        
        while (skeleton.Bones.Count == 0) 
        {
            yield return null;
        }

        tele.SetActive(true);
        textura = tele.GetComponent.<RawImage>().texture;
        videosource = tele.GetComponent.<VideoPlayer>().VideoClip;
        loop = tele.GetComponent.<VideoPlayer>().Loop;

        textura = video0;
        videosource = video0;
        loop = 0;

        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
    }
}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());

        if (hasRecognized && !currentGesture.Equals(previousGesture))
        {
            Debug.Log("New Gesture Found:" + currentGesture.name);
            //currentGesture.onRecognized.Invoke();
        }
    }
    void Save(){
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        g.fingerDatas = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentgesture = new Gesture();
        float currentMin = Mathf.Infinity;
        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
                if (distance>threshold)
                {
                    isDiscarded = true;
                    break;
                }
                sumDistance += distance;
            }

            if(!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentgesture = gesture;

            }

        }
        return currentgesture;
    }
}
