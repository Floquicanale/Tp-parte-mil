using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Chair : MonoBehaviour
{
    public GameObject ChairObject;
    public float DistanceToView = 2f;
    public Transform PlayerObject;
    public GameObject cilindro;

    private Vector3 pos_orig;
    
        
    // Update is called once per frame
    void Start(){
        pos_orig = cilindro.transform.position;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q)&&(Vector3.Distance(PlayerObject.position, ChairObject.transform.position) <= DistanceToView)){
            
            if(cilindro.transform.position.y<0){
                cilindro.transform.position = pos_orig;
                cilindro.SetActive(true);
            }else{
                Vector3 cilindroPosition =  new Vector3(1.6f, -0.35f, 2.165f);
                cilindro.transform.position = cilindroPosition;
                cilindro.SetActive(false);
            }
            
            
        }
    }
}
