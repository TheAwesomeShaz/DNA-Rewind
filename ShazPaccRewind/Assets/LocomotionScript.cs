using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using Vector3 = UnityEngine.Vector3;

public class LocomotionScript : MonoBehaviour
{
    public Transform Leg_L;
    public Transform Leg_R;
    public Transform COM_body; //Object which is moving so basically GlobalPosition
    public LayerMask grounplane;
    public Vector3 offset;

    public float thresholdWalk = 1f;
    public Transform Target_LL;
    public Transform Target_LR;

    public bool LeftInProgress, RightInProgress;

    private void Start()
    {

    }
    private void Update()
    {
        if(Vector3.Distance(Target_LL.position,Leg_L.position) > thresholdWalk )
        {

            Leg_L.position = Vector3.Lerp(Leg_L.position, Target_LL.position, 10 * Time.deltaTime);

        }else if (Vector3.Distance(Target_LR.position, Leg_R.position) > thresholdWalk )
        {
            Leg_R.position = Vector3.Lerp(Leg_R.position, Target_LR.position, 10 * Time.deltaTime);

        }

        COM_body.position = (Leg_L.position + Leg_R.position) / 2 + offset;

    }



}
