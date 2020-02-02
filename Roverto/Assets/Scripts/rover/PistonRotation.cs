using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonRotation : MonoBehaviour
{
    public GameObject Rueda;
    public GameObject Pivote;

    public Vector3 vectorPivote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pivote.transform.LookAt(Rueda.transform);
    }
}
