using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Treatment : MonoBehaviour
{
    public GameObject ChairObject;
    public float DistanceToView = 2f;
    public Transform PlayerObject;
    public GameObject cilindro;
    public GameObject TextPrefab;

    private Vector3 pos_orig;
    
    GameObject newText;

    
        
    // Update is called once per frame
    void Start(){
        pos_orig = cilindro.transform.position;

        Vector3 pos = new Vector3(ChairObject.transform.position.x, 1.4f, ChairObject.transform.position.z);   
        newText = Instantiate(TextPrefab, pos, Quaternion.Euler(0, 90, 0));

        if (Vector3.Distance(cilindro.transform.position, ChairObject.transform.position) <= DistanceToView){
            newText.SetActive(true);
        }else{        
            newText.SetActive(false);
        }
        
    }
    void Update()
    {
        if (Vector3.Distance(cilindro.transform.position, ChairObject.transform.position) <= DistanceToView){
            
            newText.SetActive(true);
            
            if (Input.GetKeyUp(KeyCode.Q)){
                if(cilindro.transform.position.y<0){
                    cilindro.transform.position = pos_orig;
                    cilindro.SetActive(true);
                }else{
                    Vector3 cilindroPosition =  new Vector3(1.6f, -0.35f, 2.165f);
                    Vector3 PlayerObjectPosition =  new Vector3(1.6f, 1.3f, 2.165f);
                    cilindro.transform.position = cilindroPosition;
                    PlayerObject.position = PlayerObjectPosition;
                    cilindro.SetActive(false);
                    newText.SetActive(false);
                    
                }
            }
            
        }else{
            newText.SetActive(false);
        }
    }
}
