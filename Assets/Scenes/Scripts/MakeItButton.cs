using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeItButton : MonoBehaviour
{
    UnityEvent event0;
    public GameObject button;
    public GameObject Camara1;
    public GameObject Camara2;
    // Start is called before the first frame update
    void Start(){
        button = this.gameObject;
        event0 = new UnityEvent();
        Camara2.GetComponent<AudioListener> ().enabled  =  false;
        event0.AddListener(Silla);
    }
        
    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject){
                event0.Invoke();
            }
        }
    }
    void Silla()
    {
        Camara2.SetActive(true);
        Camara1.SetActive(false);
        Camara2.tag = "MainCamera";
        Camara1.GetComponent<AudioListener> ().enabled  =  false;
        Camara2.GetComponent<AudioListener> ().enabled  =  true;
    }
}
