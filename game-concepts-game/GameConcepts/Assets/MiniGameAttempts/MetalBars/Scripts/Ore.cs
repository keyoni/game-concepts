using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ore : MonoBehaviour
{
    [SerializeField] private String oreType;

    [SerializeField] private int meltTemp;

    [SerializeField] private int cost;

    public bool inOven;
    [SerializeField] private Sprite barSprite;
    private Color oreColor;
    public bool onAnvil;

    public bool melted = false;
    // Start is called before the first frame update
    void Start()
    {
        oreColor = GetComponent<SpriteRenderer>().color;
    }

    public String getOreType()
    {
        return oreType;
    }

    public int getOreMeltTemp()
    {
        return meltTemp;
    }

    public void melting()
    {
        melted = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (onAnvil)
        {
            if (col.gameObject.CompareTag("Hammer"))
            {
                GetComponent<SpriteRenderer>().sprite = barSprite;
                GetComponent<SpriteRenderer>().color = oreColor;
                float rand = Random.Range(-3f, 3f);
                GetComponent<Transform>().position += new Vector3(rand, -3, 0);
            }
            
        }
    }
}
