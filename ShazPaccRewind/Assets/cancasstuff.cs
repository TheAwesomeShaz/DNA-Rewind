using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class cancasstuff : MonoBehaviour
{
    public TextMeshProUGUI distancetxt;
    public float distance;
    public RawImage x;
    public LookScript ls;
    public Slider sld;
    // Update is called once per frame
    private void Awake()
    {
        sld.value = PlayerPrefs.GetFloat("sens");
    }
    void Update()
    {
        
        ls.mouseSensitivity = sld.value;
        PlayerPrefs.SetFloat("sens", sld.value);

        if (distance >= 15)
        {
            x.color = Color.Lerp(Color.red, Color.white, Time.deltaTime * 0.4f);
        }
        else
        {
            x.color = Color.Lerp(Color.white, Color.red, Time.deltaTime * 0.4f);
        }
        distancetxt.SetText(((int)distance).ToString());
    }
}
