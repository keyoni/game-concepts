using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snappable : MonoBehaviour
{
    [SerializeField] private GameObject[] snapPoints;

    [SerializeField] private float snapDistance = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Dragable>().Released += CheckSnap;
    }

    void CheckSnap()
    {
        foreach (var snap in snapPoints)
        {
            if (Vector3.Distance(snap.transform.position, this.GetComponent<Transform>().position) < snapDistance)
            {
                GetComponent<Transform>().position = snap.transform.position;
                return;
            }
        }
    }
    
}
