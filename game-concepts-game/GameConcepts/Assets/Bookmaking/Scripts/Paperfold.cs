using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Paperfold : MonoBehaviour
{
    private bool foldedOver = false;

    private bool pastMid = false;
    
   private Vector3 mouseStart;
   private Vector3 spriteStart;

   public Ease pageEase;
    // Start is called before the first frame update
    void Start()
    {    
        DOTween.Init();
        StartCoroutine(PaperFold());
        // GetComponent<SpriteRenderer>().DOColor(Color.black ,5f);
        // transform.DOScale(new Vector3(-1,1,1),1f);
    }

  

    IEnumerator PaperFold()
    {
        Tween myTween = transform.DOScale(new Vector3(0f,1f,1f),1f);
        GetComponent<SpriteRenderer>().DOColor(Color.black ,1f)
            .SetEase(pageEase);
        yield return myTween.WaitForCompletion();
        // This log will happen after the tween has completed
        GetComponent<SpriteRenderer>().color = Color.white;
        transform.DOScale(new Vector3(-1f,1f,1f),1f)
            .SetEase(pageEase);
        Debug.Log("Tween completed!");
    }
    private void OnMouseDrag()
    {
        if (!foldedOver)
        {
            GetComponent<Transform>().localScale -= new Vector3(0.001f, 0f, 0f);
            if (GetComponent<Transform>().localScale.x < 0f && !pastMid)
            {
                pastMid = true;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if(!pastMid)
            {
                GetComponent<SpriteRenderer>().color -= new Color(0.001f, 0.001f, 0.001f, 0);
            }
         
        }
     
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        print(col.gameObject.name);
        if (col.gameObject.name.Equals("EndPoint"))
        {
            foldedOver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print(other.gameObject.name);
    }
}
