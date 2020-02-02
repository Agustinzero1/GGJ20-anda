using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PuertaBehaviour : MonoBehaviour, IActivable
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Activar()
    {
        anim.SetTrigger("Activar");
        return true;
    }

    public bool Liberar()
    {
        throw new System.NotImplementedException();
    }

    
}
