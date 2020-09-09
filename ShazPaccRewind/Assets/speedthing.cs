using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedthing : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement pa;
    public Material[] mats;
    public RawImage ri;

    // Update is called once per frame
    void Update()
    {
        foreach(Material x in mats)
        {
           // x.SetColor(new Color(0, 0, 0, pa.GetComponent<Rigidbody>().velocity.sqrMagnitude));
        }
        if(pa.GetComponent<Rigidbody>().velocity.sqrMagnitude > 30)
        {

            ri.material = mats[0];
            
        }
        else
        {
            
        }
    }
}
