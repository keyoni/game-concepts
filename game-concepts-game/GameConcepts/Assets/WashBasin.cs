using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WashBasin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        Color curColor = other.gameObject.GetComponent<SpriteRenderer>().color;
        print("Hit");
        float red = (curColor.r+0.01f  >  1f) ?  curColor.r : 0.01f+curColor.r;
        float green = (curColor.g+0.01f  >  1f) ?  curColor.g : 0.01f+curColor.g;
        float blue = (curColor.b +0.01f  >  1f) ?  curColor.b : 0.01f+curColor.b;
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(
            red,green,blue,1f);
        print(other.gameObject.GetComponent<SpriteRenderer>().color);
    }
}
