using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShowingtext : MonoBehaviour
{
    [SerializeField]
    private GameObject ControlObject;

    [SerializeField]
    private GameObject TextPrefab;

    public float DistanceToView = 2f;
    public Transform PlayerObject;

    GameObject newText;

    // Start is called before the first frame update
    void Start()
    {
        newText = Instantiate(TextPrefab, ControlObject.transform.position, Quaternion.Euler(0, 90, 0));

        if (Vector3.Distance(PlayerObject.position, ControlObject.transform.position) <= DistanceToView){
            newText.SetActive(true);
        }else{        
            newText.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(PlayerObject.position, ControlObject.transform.position) <= DistanceToView)){
            newText.SetActive(true);
        }else{        
            newText.SetActive(false);
        }
    }
}
