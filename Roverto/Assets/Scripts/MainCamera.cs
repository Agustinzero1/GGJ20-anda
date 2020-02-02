using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public int heigthDivider;
    public Vector3 fixY;
    public float smoothSpeed = 11f;
    private float initialPosZ;

    // Start is called before the first frame update
    void Awake()
    {
        initialPosZ = transform.position.z;
        Vector3 aux = new Vector3(target.transform.position.x, target.transform.position.y + Screen.height / heigthDivider, transform.position.z);
        transform.position = aux;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.LerpUnclamped(transform.position, target.position, smoothSpeed * Time.deltaTime);
        pos.z = initialPosZ;
        pos.y = pos.y + Screen.height/ heigthDivider;
        transform.position = pos;
    }
}
