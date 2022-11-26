using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairShowingText : MonoBehaviour
{
    [SerializeField]
    private GameObject ChairObject;

    [SerializeField]
    private GameObject TextPrefab;

    public float DistanceToView = 2f;
    public GameObject cilindro;

    GameObject newText;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(ChairObject.transform.position.x, 1.4f, ChairObject.transform.position.z);   
        newText = Instantiate(TextPrefab, pos, Quaternion.Euler(0, 90, 0));

        if (Vector3.Distance(cilindro.transform.position, ChairObject.transform.position) <= DistanceToView){
            newText.SetActive(true);
        }else{        
            newText.SetActive(false);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(cilindro.transform.position, ChairObject.transform.position) <= DistanceToView){
            newText.SetActive(true);
        }else{        
            newText.SetActive(false);
        }
    }
}
