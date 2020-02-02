using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepe : MonoBehaviour
{
    public Camera _cam;

    public Camera cam {
        get {
            if (_cam == null){
                _cam = Camera.main;
            }
            return _cam;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        this.transform.position = Vector3.Scale( cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,0)), new Vector3(1,1,0));
    }
}
