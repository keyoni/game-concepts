using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject redLever, blueLever, greenLever;
    [SerializeField] private GameObject colorObj;

    public Color currentColor;
    // Start is called before the first frame update
    void Start()
    {
        Rotatable.AngleChanged += GetNewColor;
    }
    void GetNewColor()
    {
        float  rChange, bChange, gChange;
         rChange = redLever.GetComponent<ColorLever>().colorLevel;
         gChange = greenLever.GetComponent<ColorLever>().colorLevel;
         bChange = blueLever.GetComponent<ColorLever>().colorLevel;

         float r, b, g;

         r = 1 - (gChange + bChange);
         g = 1 - (rChange + bChange);
         b = 1 - (gChange + rChange);

         currentColor = new Color(r, g, b);
         colorObj.GetComponent<ColorChangeable>().ChangeColor(currentColor);
    }
}
