using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointadder : MonoBehaviour
{
    public ParticleSystem pp;
    public playerscore ps;
    public GameObject deathanime;
    public int score;
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        ps.score += 1;
        Instantiate(deathanime,this.gameObject.transform.position,Quaternion.identity);
        Object.Destroy(this.gameObject);
        
    }
}
