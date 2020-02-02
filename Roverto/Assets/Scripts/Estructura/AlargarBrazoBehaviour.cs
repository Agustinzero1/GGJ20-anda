using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlargarBrazoBehaviour : MonoBehaviour
{
    public float LongitudMaxima = 1;
    public float LongitudMinima = .5f;
    public float LongitudBrazo = 1;
    public float DeltaScroll = .2f;
    float dy = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        dy = Input.mouseScrollDelta.y;

        if(Mathf.Abs(dy) > 0){
            Vector3 NuevaEscala = this.transform.localScale + new Vector3(0, 0, dy * DeltaScroll) ;
            NuevaEscala.z = Mathf.Clamp( NuevaEscala.z, LongitudMinima, LongitudMaxima);
            //Debug.Log(NuevaEscala);

            this.transform.localScale = NuevaEscala;
        }

    }



    
}
