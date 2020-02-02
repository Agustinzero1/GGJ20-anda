using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Objetivo2DBehaviour : MonoBehaviour, IActivable
{
    private Collider2D alcance {get;set;}

    public AlargarBrazoBehaviour alargue;

    // Start is called before the first frame update
    void Start()
    {
        alcance = GetComponent<Collider2D>();
        alcance.isTrigger = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool Activar()
    {
        alargue.LongitudMaxima += 1;

        return true;
    }

    public bool Liberar()
    {
        throw new System.NotImplementedException();
    }
}
