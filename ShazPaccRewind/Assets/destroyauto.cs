using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyauto : MonoBehaviour
{
    public float timeToDie = 5;
    private void Start()
    {
        StartCoroutine("secondstowait",timeToDie);
    }
    IEnumerator secondstowait(float time)
    {
        yield return new WaitForSeconds(time);
        Object.Destroy(this.gameObject);

    }
}
