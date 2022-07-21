using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HoverOutline : MonoBehaviour
{
    private Sprite _parentSprite;

    [SerializeField] private GameObject hoverObjPreFab;
    [SerializeField] private float outlineThickness = 0.05f;

    public GameObject hover;

    private SpriteRenderer hoverRenderer;

    //public static event Action<GameObject,GameObject> CreatedHover;

    private Color hoverColor;
    // Start is called before the first frame update
    void Start()
    {
      CreateHoverObj();
      hoverColor = hover.GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
        if (this.gameObject.GetComponent<Draggable>() != null)
        {
            if (!this.gameObject.GetComponent<Draggable>().isHeld)
            {
                print("MouseEnter");
                hover.GetComponent<SpriteRenderer>().color = new Color(hoverColor.r, hoverColor.g, hoverColor.b, 1);
                print("Hover Script " + hover.GetComponent<SpriteRenderer>().color);

            }
        }
    }

    private void OnMouseExit()
    {
        if (this.gameObject.GetComponent<Draggable>() != null)
        {
            if (!this.gameObject.GetComponent<Draggable>().isHeld)
            {
                print("Exit");
                hover.GetComponent<SpriteRenderer>().color = new Color(hoverColor.r, hoverColor.g, hoverColor.b, 0);
            }
        }
    }

    void CreateHoverObj()
    {
        hover =   Instantiate(hoverObjPreFab,transform.position,transform.localRotation,this.gameObject.transform);
        hoverRenderer = hover.GetComponent<SpriteRenderer>();
        hoverRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
        hoverRenderer.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
        hover.GetComponent<Transform>().localScale += new Vector3(outlineThickness, outlineThickness, outlineThickness);
        print("Created Hover");
        //CreatedHover?.Invoke(hover,this.gameObject);
        if (this.gameObject.GetComponent<Draggable>() != null)
        {
            this.gameObject.GetComponent<Draggable>().SetHover(hover);
        }
    }
}
