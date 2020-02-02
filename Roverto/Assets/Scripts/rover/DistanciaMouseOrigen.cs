using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanciaMouseOrigen : MonoBehaviour
{
    public GameObject Rueda;
    public GameObject basepivote;
    public float distanciaRueda;
    public float DistanciaX2;
    public float DistanciaMenosAnterior;
    public float Anterior0;
    public float Anterior1;
    public float Anterior2;
    public float Anterior3;
    public float Anterior4;
    public float Anterior5;
    public float Anterior6;
    public int AstaDondeRestar;
    public float distanciaSuma;
    // Start is called before the first frame update
    void Start()
    {
        distanciaSuma = Anterior0 + Anterior1 + Anterior2 + Anterior3 + Anterior4 + Anterior5 + Anterior6;
    }

    // Update is called once per frame
    void Update()
    {
        distanciaRueda = Vector3.Distance(basepivote.transform.position, Rueda.transform.position);
        DistanciaX2 = distanciaRueda * 2;

        switch (AstaDondeRestar)

        {

            case 1:
                //primera barra M 
                DistanciaMenosAnterior = (distanciaRueda - (Anterior0)) * 2;
                break;

            case 2:
                //segunda barra M
                DistanciaMenosAnterior = (distanciaRueda - (Anterior0 + Anterior1)) * 2;
                break;

            case 3:
                //primera barra F
                DistanciaMenosAnterior = (distanciaRueda - (Anterior0 + Anterior1 + Anterior2)) * 2;
                break;

            case 4:
                //segunda barra F
                DistanciaMenosAnterior = (distanciaRueda - (Anterior0 + Anterior1 + Anterior2 + Anterior3)) * 2;
                break;

            case 5:
                //Tercera barra F
                DistanciaMenosAnterior = (distanciaRueda - (Anterior0 + Anterior1 + Anterior2 + Anterior3 + Anterior4)) * 2;
                break;

            case 6:
                //Tercera barra F
                DistanciaMenosAnterior = (distanciaRueda - (Anterior0 + Anterior1 + Anterior2 + Anterior3 + Anterior4 + Anterior5)) * 2;
                break;

            default:
                Debug.Log("el caso es incorrecto, setear correctamente barraACalcular");
                break;
        }
    }
}
