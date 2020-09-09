using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powercubespawner : MonoBehaviour
{
    public GameObject bigpcube;
    public float noOfInstances = 12;
    public int radius = 4;
    public SphereCollider s;
    [System.Obsolete]
    private void Start()
    {
        for(int i = 0; i < noOfInstances; i++)
        {
            Instantiate(bigpcube,transform.position + new Vector3(Random.RandomRange(0, s.radius),
                Random.RandomRange(0, s.radius), Random.RandomRange(0, s.radius)), Quaternion.identity);
        }
    }

}
