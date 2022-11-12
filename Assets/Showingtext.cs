using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showingtext : MonoBehaviour
{
    [SerializeField]
    private GameObject ControlObject;

    [SerializeField]
    private GameObject TextPrefab;

    [SerializeField]
    private float KillTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newText = Instantiate(TextPrefab, ControlObject.transform.position, Quaternion.Euler(0, 90, 0));
        newText.SetActive(true);
        Destroy(newText.gameObject, KillTime);
        //newText.GetComponent<SetText>().SetTextFunction("Presione la tecla E");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            GameObject newText = Instantiate(TextPrefab, ControlObject.transform.position, Quaternion.Euler(0, 90, 0));
            newText.SetActive(true);
            Destroy(newText.gameObject, KillTime);
            //newText.GetComponent<SetText>().SetTextFunction("Presione la tecla E");
        }
    }
}
