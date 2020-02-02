using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuertaBehaviour : MonoBehaviour, IActivable
{
    public bool EstaAbierta = false;
    public float Direccion = 0;

    public PuertaBehaviour[] Puertas;

    public bool Activar()
    {
        Debug.Log("En BotonPuerta");

        foreach(var Puerta in Puertas){
                Puerta.Activar();      
        } 

        return true;
    }

    public bool Liberar()
    {

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
