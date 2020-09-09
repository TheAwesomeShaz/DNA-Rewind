using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playerscore : MonoBehaviour
{
   public int score;
    public TextMeshProUGUI tmesh;
    void Start()
    {
        score = 0;
        tmesh.SetText(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        tmesh.SetText(score.ToString());
    }
}
