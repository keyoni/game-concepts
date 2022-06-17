using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNodes : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        manager.GetComponent<ABCNodeManager>().ResetNodes();
    }
}
