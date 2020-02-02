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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(axisAction) > 0)
        {
            spriteRender.sprite = pinzaCerrada;
            if (ObjetoTocado != null) {
            }
        }
        else
        {
            spriteRender.sprite = pinzaAbierta;
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
