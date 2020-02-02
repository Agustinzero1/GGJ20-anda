using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Interactuable _interactuable;

    public bool estadoBoton;
    public bool estadoBotonInterno;

    private void Start()
    {
        estadoBotonInterno = estadoBoton;
    }
    // Update is called once per frame
    void Update()
    {
        if (estadoBoton != estadoBotonInterno) {
            _interactuable.activado = estadoBoton;
            estadoBotonInterno = estadoBoton;
        }
    }
}
