using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wipe : MonoBehaviour
{
    public float cleanPower;

    // Start is called before the first frame update
    void Start()
    {
        cleanPower = 0;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {  

      
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Dirt"))
        {
            GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color + new Color(0.015f,0.040f,0f,1f);
            cleanPower -= 0.005f;
            if (cleanPower <= 0) cleanPower = 0;
            
        }
    }
}
