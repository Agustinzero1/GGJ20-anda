using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarBehaviour : MonoBehaviour, IActivable
{

    private Collider2D alcance {get;set;}

    // Start is called before the first frame update
    void Start()
    {
        alcance = GetComponent<Collider2D>();
        alcance.isTrigger = true;
        
    }

    public bool Activar()
    {
        

        return true;
    }

    public bool Liberar()
    {
        return true;
    }
}
