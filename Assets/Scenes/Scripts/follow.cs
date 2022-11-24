using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject cilindro;
    public GameObject Camara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posx = cilindro.transform.position.x;
        float posz = cilindro.transform.position.z;
        Vector3 pos = new Vector3(posx, 1.6f, posz);
        Camara.transform.position = pos;

    }
}
