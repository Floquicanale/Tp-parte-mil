using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class startTreatment : MonoBehaviour
{
    public GameObject Camara1;
    public GameObject Camara2;
        
    public void Silla()
    {
        Camara2.SetActive(true);
        Camara1.SetActive(false);
        //Camara1.GetComponent<AudioListener> ().enabled  =  false;
        //Camara2.GetComponent<AudioListener> ().enabled  =  true;
    }
}