using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinza : MonoBehaviour
{
    public bool debug;
    public SpriteRenderer spriteRender;
    public Sprite pinzaAbierta;
    public Sprite pinzaCerrada;
    public string axisAction;
    public GameObject ObjetoTocado;
    public bool siEstaApretada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis(axisAction) > 0 )
        {
            if (siEstaApretada == false) {
                siEstaApretada = true;
                spriteRender.sprite = pinzaCerrada;
                if (ObjetoTocado != null)
                {
                    if (ObjetoTocado.layer == 11)
                    {
                        Boton botontTocado = (ObjetoTocado.GetComponent("Boton") as Boton);
                        botontTocado.estadoBoton = !botontTocado.estadoBoton;
                    }

                }
            }
            
        }
        else
        {
            spriteRender.sprite = pinzaAbierta;
            siEstaApretada = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (debug)    Debug.Log("Toque " + collision.name);
         ObjetoTocado = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (debug)  Debug.Log("deje de tocar a " + collision.name);
        if (ObjetoTocado = collision.gameObject)    ObjetoTocado = null;
    }

}
