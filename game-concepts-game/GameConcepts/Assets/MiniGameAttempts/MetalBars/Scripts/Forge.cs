using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Forge : MonoBehaviour
{
    [SerializeField] private Transform snapPoint;
    [SerializeField] private SpriteRenderer heatLight;
 
    private List<GameObject> oresInForge;

    private String currentOreType;

    private bool melting = false;
    // Start is called before the first frame update
    void Start()
    {
        oresInForge = new List<GameObject>();
        DialSnapPoints.DialSet += CheckLevel;
        heatLight.color = Color.grey;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ore"))
        {
            if (oresInForge.Count < 1)
            {
                currentOreType = col.gameObject.GetComponent<Ore>().getOreType();
            }
            oresInForge.Add(col.gameObject);
            col.gameObject.GetComponent<Ore>().inOven = true;
            print(string.Join(", ", oresInForge));;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ore"))
        {
            if (other.gameObject.GetComponent<Dragable>().isHeld == false)
            {
                other.gameObject.GetComponent<Transform>().position = snapPoint.position;
                if (!other.GetComponent<Ore>().getOreType().Equals(currentOreType))
                {
                   WrongOre(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Ore"))
        {
            oresInForge.Remove(other.gameObject);
            print(string.Join(", ", oresInForge));
            //print(other.gameObject.GetComponent<Ore>().getOreType());
            other.gameObject.GetComponent<Ore>().inOven = false;
        }
    }

    private void WrongOre(GameObject ore)
    {
        float rand = Random.Range(-3f, 3f);
        oresInForge.Last().GetComponent<Transform>().position += new Vector3(rand, -3, 0);
        print("Wrong");
    }

    void CheckLevel(int value)
    {
        if (oresInForge.Count >= 1)
        {
            int currentMeltingTemp = oresInForge[0].GetComponent<Ore>().getOreMeltTemp();
            if (value == currentMeltingTemp)
            {
                print("Melting " + currentOreType);
                heatLight.color = Color.green;
                Forging();
            }
            else
            {
                if (value < currentMeltingTemp)
                {
                    print("Forge Too Cold");
                    heatLight.color = Color.blue;
                }
                else
                {
                    print("Forge Too Hot");
                    heatLight.color = Color.red;
                }
            }
        }

        
    }

    void Forging()
    {
        StartCoroutine(DropHotOres());
    }


    IEnumerator DropHotOres()
    {
        int totalOres = oresInForge.Count;
        for(int i = 0; i < totalOres; i++ )
        {
            oresInForge[0].GetComponent<SpriteRenderer>().color += new Color(0.5f, -0.1f, -0.1f, 0f);
            oresInForge[0].GetComponent<Ore>().melting();
            float rand = Random.Range(-3f, 3f);
            oresInForge.First().GetComponent<Transform>().position += new Vector3(rand, -3, 0);
            yield return new WaitForSeconds(0.5f);
         
        }
        heatLight.color = Color.grey;
    }

}
