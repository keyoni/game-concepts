using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

public class Tool : MonoBehaviour 
{
    [SerializeField] private GameObject activeToolManager;
    private String toolType;
    
    private void OnMouseUpAsButton()
    {
        print("Current Tool" +  gameObject.name);
        activeToolManager.GetComponent<ActiveTool>().ActivateTool(this.gameObject);
    }

    
}
