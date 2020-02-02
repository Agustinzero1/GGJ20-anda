using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSeguirBehaviour : MonoBehaviour
{

    public Transform Referencia; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Referencia.transform.position;
        
    }
}
