using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABCNodeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> abcNodes;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ResetNodes()
    {
        print("All Nodes Reset - START");
        foreach (var node in abcNodes)
        {
            node.GetComponent<WheelPoint>().ResetSelected();
            print(node.name + "Reseted");
        }
        print("All Nodes Reset");
    }
    
}
