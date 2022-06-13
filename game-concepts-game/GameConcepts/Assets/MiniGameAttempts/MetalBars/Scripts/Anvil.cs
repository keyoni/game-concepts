using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{

    [SerializeField] private Transform snapPoint;
    [SerializeField] private Transform rawSnap;
    private bool occupied = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (occupied) return;
        if (!other.gameObject.CompareTag("Ore")) return;
        if (other.gameObject.GetComponent<Dragable>().isHeld != false) return;
        if (other.gameObject.GetComponent<Ore>().melted)
        {
            other.gameObject.GetComponent<Transform>().position = snapPoint.position;
            occupied = true;
            print("Occupied");
            other.gameObject.GetComponent<Ore>().onAnvil = true;
        }
        else
        {
            print("Not Melted Or Spot Taken");
            other.gameObject.GetComponent<Transform>().position = rawSnap.position;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ore"))
        {
            occupied = false;
            other.gameObject.GetComponent<Ore>().onAnvil = false;
        }
    }
}
