using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using UnityEngine.Video;


public class GestureDetectorR1 : MonoBehaviour
{

    public float threshold = 0.1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones;
    private Gesture previousGesture;
    public VideoClip video0;
    public VideoClip video1;
    public VideoClip video2;
    public VideoClip video3;
    public VideoClip video4;
    public VideoClip video5;
    public GameObject tele;
    private VideoPlayer videosource;
    private AudioSource ting;
    public GameObject manos;
    public Material checkmat;
    private Material normalmat;
    private bool v0 = false;
    private bool v1 = false;

    IEnumerator Start(){
        
        
        while (skeleton.Bones.Count == 0) 
        {
            yield return null;
        }
        
        videosource = tele.GetComponent<VideoPlayer>();
        ting = tele.GetComponent<AudioSource>();
        videosource.clip = video0;
        videosource.isLooping = false;
        tele.SetActive(true);

        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
        normalmat = manos.GetComponent<SkinnedMeshRenderer>().material;
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());

        if(!videosource.isPlaying && !v0){
            videosource.clip = video1;
            videosource.Play();
            videosource.isLooping = true;
            v0=true;
        }

        if (hasRecognized && !currentGesture.Equals(previousGesture))
        {
            if(currentGesture.name == "thumb down" && v0 && !v1){
                ting.Play();
                videosource.clip = video2;
                videosource.Play();
                videosource.isLooping = true;
                while(ting.isPlaying){
                    manos.GetComponent<SkinnedMeshRenderer>().material = checkmat;
                }
                manos.GetComponent<SkinnedMeshRenderer>().material = normalmat;
                v1 = true;
            }

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
