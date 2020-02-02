using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonBrazo : MonoBehaviour
{

    public GameObject Objetivo;
    public GameObject BasePivote;
    public float DistanciaMouse;
    public float DistanciaMouseAcotada;
    public Vector3 vector;

    public float DistanciaMax = 13.93f;
    public float DistanciaMin = 3.63f;

    public float distanciaPinzaMouse;

    public float distanciaX;
    public float posicionMax;
    public float posicionDistMin;
    public float posicionMin;

    public int LevelActual;
    public int LevelActualInterno;
    public float DistanciaLVL1;
    public float DistanciaLVL2;
    public float DistanciaLVL3;
    public float DistanciaLVL1Porcentaje;
    public float DistanciaLVL2Porcentaje;
    // Start is called before the first frame update
    void Awake()
    {
       
        posicionMax = transform.localPosition.x;
        posicionMin = posicionMax - posicionDistMin;
        DistanciaLVL3 = DistanciaMax;
        DistanciaLVL2 = (DistanciaLVL3 / 100)*DistanciaLVL2Porcentaje;
        DistanciaLVL1 = (DistanciaLVL3 / 100) * DistanciaLVL1Porcentaje;

        
        LevelActual = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelActual == 1 && LevelActualInterno != LevelActual) {
            LevelActualInterno = LevelActual;
            DistanciaMax = DistanciaLVL1;
        }

        if (LevelActual == 2 && LevelActualInterno != LevelActual)
        {
            LevelActualInterno = LevelActual;
            DistanciaMax = DistanciaLVL2;
        }

        if (LevelActual == 3 && LevelActualInterno != LevelActual)
        {
            LevelActualInterno = LevelActual;
            DistanciaMax = DistanciaLVL3;
        }

        //obtengo distancia del mouse
        DistanciaMouse = Vector3.Distance(BasePivote.transform.position, Objetivo.transform.position);

        if (DistanciaMouse >= DistanciaMin && DistanciaMouse <= DistanciaMax)
        {
            DistanciaMouseAcotada = DistanciaMouse;
        }
        else {
            if (DistanciaMouse < DistanciaMin) {
                DistanciaMouseAcotada = DistanciaMin;
            }
            if (DistanciaMouse > DistanciaMax){
                DistanciaMouseAcotada = DistanciaMax;
            }
        }

        //si es esta por encima del minimo (en realidad por debajo por ser negativo)
        //calcula la posicion en tiempo real en x
        if (-DistanciaMouseAcotada - distanciaX < posicionMin)
        {
            vector.x = -DistanciaMouseAcotada - distanciaX;
        }

        //si me paso del minimo me quedo con el minimo de apertura
        if (-DistanciaMouseAcotada - distanciaX > posicionMin)
        {
            vector.x = posicionMin;
        }

        //si me paso del maximo me quedo en el maximo de apertura
        if (-DistanciaMouseAcotada - distanciaX < posicionMax)
        {
            vector.x = posicionMax;
        }

        //lo muevo con lo calculado
        transform.localPosition = vector;


    }
}
