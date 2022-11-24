using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showingtext : MonoBehaviour
{
    [SerializeField]
    private GameObject ControlObject;

    [SerializeField]
    private GameObject TextPrefab;

    //[SerializeField]
    //private float KillTime;

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
        
        //Destroy(newText.gameObject, KillTime);
        //newText.GetComponent<SetText>().SetTextFunction("Presione la tecla E");
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject newText = Instantiate(TextPrefab, ControlObject.transform.position, Quaternion.Euler(0, 90, 0));
        if ((Vector3.Distance(PlayerObject.position, ControlObject.transform.position) <= DistanceToView)){
            //GameObject newText = Instantiate(TextPrefab, ControlObject.transform.position, Quaternion.Euler(0, 90, 0));
            newText.SetActive(true);
            //Destroy(newText.gameObject, KillTime);
            //newText.GetComponent<SetText>().SetTextFunction("Presione la tecla E");
        }else{        
            newText.SetActive(false);
        }
        //Destroy(newText.gameObject, 1);
    }
}
