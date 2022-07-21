using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Draggable : MonoBehaviour
{
   private Vector3 mouseStart;
   private Vector3 spriteStart;
   public bool isHeld = false;

   [SerializeField] private bool changeOpacity;
   [SerializeField] private float opacityChangeLevel = 0.75f;
   private bool hasHover = false;
   [SerializeField] private GameObject hoverObj;

   private bool opacActive;
   //public event Action Released;

   private void Start()
   { 
      //HoverOutline.CreatedHover += SetHover;
      print("Start");
   }

   private void OnMouseDown()
   { 
      isHeld = true;
      mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      spriteStart = this.transform.localPosition ;

   }

   public void SetHover(GameObject hover)
   {
      // print(parent + " "+this.gameObject);
      //
      // if (parent.Equals(this.gameObject))
      // {
         print("HASHOVER");
         hoverObj = hover;
         hasHover = true;
      // }
   }
   private void OnMouseDrag()
   {
      if (isHeld)
      {
         transform.localPosition = spriteStart + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseStart);

         if (changeOpacity && !opacActive)
         {
            
            opacActive = true;
            GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, opacityChangeLevel);
            print("Top" + GetComponent<SpriteRenderer>().color);
            if (hasHover)
            {
               //GetComponentInChildren<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.90f);
               hoverObj.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, opacityChangeLevel);
               print("Hover" + hoverObj.GetComponent<SpriteRenderer>().color);
            }
         }
      }
   }

   private void OnMouseUp()
   {
      //Released?.Invoke();
 
      isHeld = false;
      if (changeOpacity)
      {
         opacActive = false;
         GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, opacityChangeLevel);
         
         print("Top Up" + GetComponent<SpriteRenderer>().color);
         if (hasHover)
         {
            hoverObj.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, opacityChangeLevel);
            print("Hover Up" + hoverObj.GetComponent<SpriteRenderer>().color);
         }
         
      }
   }
}
