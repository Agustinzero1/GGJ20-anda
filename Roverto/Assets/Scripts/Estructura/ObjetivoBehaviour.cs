using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObjetivoBehaviour : MonoBehaviour, IObjetivo
{
    private Collider alcance {get;set;}

    // Start is called before the first frame update
    void Start()
    {
        alcance = GetComponent<Collider>();
        alcance.isTrigger = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Tomar()
    {
        
        GameObject.Destroy(this.gameObject, 2);
        return true;
    }



}
