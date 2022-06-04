using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject activeToolManager;
   
    private void OnMouseUpAsButton()
    {
        print("Clicked on");
        activeToolManager.GetComponent<ActiveTool>().ToolAction(this.gameObject);

    }
}
