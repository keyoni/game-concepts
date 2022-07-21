using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActiveTool : MonoBehaviour
{
    private String activeToolObj;
    // Start is called before the first frame update
    void Start()
    {
        activeToolObj = "Empty";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTool(GameObject tool)
    {
        activeToolObj = tool.name;
    }

    public void ToolAction(GameObject item)
    {
        switch (activeToolObj)
        {
            case "ScaleUp":
                print(activeToolObj);
                item.transform.localScale += Vector3.one;
                break;
            case "ScaleDown":
                print(activeToolObj);
                item.transform.localScale -= Vector3.one;
                break;
            case "ColorChanger":
                print(activeToolObj);
                item.GetComponent<SpriteRenderer>().color= item.GetComponent<SpriteRenderer>().color == Color.blue ||item.GetComponent<SpriteRenderer>().color == Color.white ? Color.red : Color.blue;
                break;
            case "Rotate":
                print(activeToolObj);
                item.transform.Rotate(Vector3.forward*70);  ;
                break;
            case "Empty":
                break;
        }
    }
}
