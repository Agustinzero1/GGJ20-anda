using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public bool activado = false;
    public enum tipo { boton, item, objetoLanzable}
    public tipo _tipoDeObjetoInteractuable;
    public GameObject _gameobject;
    public Puerta ControladorPuerta;

    // Start is called before the first frame update
    void Start()
    {
        if (_tipoDeObjetoInteractuable == tipo.boton) {
            ControladorPuerta = _gameobject.GetComponent("Puerta") as Puerta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_tipoDeObjetoInteractuable == tipo.boton)
        {
            ControladorPuerta.state = activado;
        }


    }
}
