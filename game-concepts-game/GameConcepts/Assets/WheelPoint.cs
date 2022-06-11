using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPoint : MonoBehaviour
{
    public int level = 0;

    private bool selected = false;

    private bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (selected)
        {
            print("CONFIRMED" + gameObject.name);
            selected = false;
        }
        else
        {
            print("Skipped");
            left = true;
            selected = false;
            //StopCoroutine(SelectLetter());
        }
        level++;
        print(level);
       
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     throw new NotImplementedException();
    // }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print(gameObject.name);
        StartCoroutine(SelectLetter());
    }

    IEnumerator SelectLetter()
    {
        
        yield return new WaitForSeconds(1f);
        
        if (!left)
        {
            print(gameObject.name + " Selected***");
            GetComponent<SpriteRenderer>().color = Color.green;
            selected = true;
        }
        else
        {
            left = false;
        }
    }

    public void ResetSelected()
    {
        selected = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
