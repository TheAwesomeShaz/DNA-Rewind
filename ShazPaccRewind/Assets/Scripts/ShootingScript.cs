using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public ParticleSystem ps;
    private bool canshoot;

    [System.Obsolete]
    void Start()
    {
        ps.enableEmission = false;
        canshoot = true;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(Input.GetMouseButton(0) && canshoot){
            ps.enableEmission = true;

            StartCoroutine("CoolDownForShooting");
        }
        else
        {
            ps.enableEmission = false;
        }

    }

    IEnumerator CoolDownForShooting()
    {
        yield return new WaitForSeconds(1f);
        canshoot = false;
        yield return new WaitForSeconds(0.5f);
        canshoot = true;
    }
}
