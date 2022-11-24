using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeItButton : MonoBehaviour
{
    UnityEvent event0;
    public GameObject button;
    public GameObject Camara1;
    public GameObject cilindro;
    // Start is called before the first frame update
    void Start(){
        button = this.gameObject;
        event0 = new UnityEvent();
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
        Vector3 positions =  new Vector3(1.6f, 1.4f, 2.165f);
        cilindro.transform.position = positions;
        Camara1.transform.position = positions;
        cilindro.SetActive(false);
    }
}
