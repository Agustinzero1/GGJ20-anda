using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotBehaviour : MonoBehaviour
{
    int CantidadObjetivosTomados { get; set; }

    private AlcanceBehaviour _Brazo {get;set;}

    private AlcanceBehaviour Brazo {
        get{
            if(_Brazo is null) {
                _Brazo = GetComponentInChildren<AlcanceBehaviour>();
            }
            return _Brazo;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TomarObjetivo(){

        IObjetivo Objetivo = Brazo.ObtenerAlcanzable();
        
        Debug.Log(((ObjetivoBehaviour) Objetivo ).gameObject.name);

        if(Objetivo is null)
            return;

        mejorarBrazo();
        Objetivo.Tomar();
    }

    void mejorarBrazo(){
        Brazo.LongitudBrazo++; 

    }

    
}
