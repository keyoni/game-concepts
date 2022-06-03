using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        this.GetComponent<SpriteRenderer>().color -=
            new Color(0f, 0f, 0f, col.gameObject.GetComponent<Wipe>().cleanPower);
        
    }
}
