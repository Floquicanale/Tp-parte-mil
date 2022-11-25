using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject cilindro;
    public GameObject Camara;
    private float posy_orig;

    // Start is called before the first frame update
    void Start()
    {
        posy_orig = cilindro.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float posx = cilindro.transform.position.x;
        float posy = cilindro.transform.position.y;
        float posz = cilindro.transform.position.z;

        float deltay = posy-posy_orig;
        Vector3 pos = new Vector3(posx, 1.6f+deltay, posz);
        Camara.transform.position = pos;

    }
}
