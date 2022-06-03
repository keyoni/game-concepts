using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        print("HIt");
        col.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        col.gameObject.GetComponent<Wipe>().cleanPower = 0.1f;
    }
}
