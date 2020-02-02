using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{

    public GameObject Rueda;
    public GameObject basepivote;
    public float distanciaRueda;
    public float movimiento;
    public Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanciaRueda = Vector3.Distance(basepivote.transform.position, Rueda.transform.position);

        vector.z = distanciaRueda * movimiento;

        transform.localPosition = vector;


    }
}
