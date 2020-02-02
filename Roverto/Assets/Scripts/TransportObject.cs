using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportObject : MonoBehaviour
{
    public GameObject objetoAMover;
    public GameObject objetivo;

    public float frames;
    public float cadaXFrames;
    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames % cadaXFrames == 0) {
            objetoAMover.transform.position = objetivo.transform.position;
        }
        
    }
}
