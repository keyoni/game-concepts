using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLever : MonoBehaviour
{
    private Color leverColor;

    private float leverAngle;
    // Start is called before the first frame update
    void Start()
    {
       leverColor = GetComponent<SpriteRenderer>().color;
       Rotatable.LeverLevel += SetAngle;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetAngle(float a)
    {
        leverAngle = a;
    }
}
