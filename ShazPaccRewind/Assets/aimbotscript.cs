using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class aimbotscript : MonoBehaviour
{
    public Transform maincamera;
    public LayerMask whatIsGrappleable;
    public Camera cam;
    public RectTransform reticle;
    private Vector3 screenspace;
    private Vector3 velocity;
    private Vector3 defaultpos;

    private void Awake()
    {
        defaultpos = reticle.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(maincamera.position, 1.5f, maincamera.forward, out hit, Mathf.Infinity, whatIsGrappleable))
        {
            this.gameObject.GetComponent<RawImage>().enabled = true;
            var x = cam.WorldToScreenPoint(hit.point);
            reticle.position = Vector3.SmoothDamp(screenspace,x , ref velocity, Time.deltaTime*120f);
            screenspace = x;
        }
        else
        {
            this.gameObject.GetComponent<RawImage>().enabled = false;
        }
    }
}
