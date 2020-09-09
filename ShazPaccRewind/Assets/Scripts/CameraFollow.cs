using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float smoothening;
    public Vector3 offset;
    public float rotationSpeed = 0.1f;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotationSpeed * Time.deltaTime);
    }
}
