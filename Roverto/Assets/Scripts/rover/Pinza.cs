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
    public GameObject particulas;
    public PistonBrazo _PistonBrazo1;
    public PistonBrazo _PistonBrazo2;
    public PistonBrazo _PistonBrazo3;
    public PistonBrazo _PistonBrazo4;
    public PistonBrazo _PistonBrazo5;

    public AntennaButton AntenaButton;
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
                        Interactuable botontTocado = (ObjetoTocado.GetComponent("Interactuable") as Interactuable);
                        botontTocado.ActivarDesactivar();
                    }
                    if (ObjetoTocado.layer == 12)
                    {
                        if (debug) Debug.Log("ObjetoTocado.layer == 12");
                        //toque el lvl up
                        Instantiate(particulas, ObjetoTocado.transform.position, Quaternion.identity);
                        _PistonBrazo1.LevelActual += 1;
                        _PistonBrazo2.LevelActual += 1;
                        _PistonBrazo3.LevelActual += 1;
                        _PistonBrazo4.LevelActual += 1;
                        _PistonBrazo5.LevelActual += 1;
                        Destroy(ObjetoTocado);
                    }
                    if (ObjetoTocado.layer == 13)
                    {
                        AudioManager.instance.PlayFx("11");
                        AntenaButton.StartCoroutine("Ganar");
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
