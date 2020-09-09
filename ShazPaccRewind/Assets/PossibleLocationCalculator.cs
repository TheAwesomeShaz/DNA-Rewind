using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibleLocationCalculator : MonoBehaviour
{
    public Transform[] RayStart = new Transform[2];
    public Transform[] TargetLoc = new Transform[2];
    public Transform[] LegTargets = new Transform[2];
    public Transform[] feetNormalize = new Transform[2];
    public LayerMask groundlayer;


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 2; i++)
        {
            RaycastHit hit;
            Physics.Raycast(RayStart[i].position, Vector3.down, out hit, 3f, groundlayer);
            if (hit.point != null)
            {
                TargetLoc[i].position = hit.point;
                var normal = hit.normal;
                var feetrot = feetNormalize[i].up;
                feetNormalize[i].rotation = Quaternion.Slerp(feetNormalize[i].rotation,Quaternion.FromToRotation(feetrot,normal),2*Time.deltaTime);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 2; i++)
        {

            Gizmos.DrawSphere(TargetLoc[i].position, 0.1f);
            Gizmos.DrawLine(LegTargets[i].position, TargetLoc[i].position);
        }
    }
}
