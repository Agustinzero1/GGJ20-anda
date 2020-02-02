using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDobleBehaviour : MonoBehaviour, IActivable
{
    public List<PuertaBehaviour> Puertas;

    public bool Activar()
    {
        foreach(var puerta in Puertas) {
            puerta.Activar();
        }
        return true;
    }

    public bool Liberar()
    {
        throw new System.NotImplementedException();
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
