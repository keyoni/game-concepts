using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSelector : MonoBehaviour
{
    [SerializeField] private GameObject oreType;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = oreType.GetComponent<SpriteRenderer>().color;
        Instantiate(oreType, GetComponent<Transform>().localPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        //Instantiate(oreType, Camera.main.ScreenToWorldPoint(mousePos) + new Vector3(0,0,10),Quaternion.identity);
        
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        //print("leaving");
        Instantiate(oreType, GetComponent<Transform>().localPosition, Quaternion.identity);
    }
}
