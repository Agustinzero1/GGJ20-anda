using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    public Animator animatorPuerta;
    public string BoolAnimator;
    public bool state;
    public bool Internalstate;

   
    public bool seAutocierra;
    public float tiempoParaAutoCerrar;
    public float _tiempoParaAutoCerrar;
    // Start is called before the first frame update
    void Start()
    {


        if (animatorPuerta == null) {
            animatorPuerta = this.GetComponent("Animator") as Animator;
        }

        state = animatorPuerta.GetBool(BoolAnimator);
        Internalstate = state;
    }

    // Update is called once per frame
    void Update()
    {

        if (seAutocierra == false) {

        }


        if (Internalstate != state && seAutocierra == false)
        {
            animatorPuerta.SetBool(BoolAnimator, state);
            Internalstate = state;
        }
    }
}
