using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RobotBehaviour))]
public class InputBehaviour : MonoBehaviour
{
    private RobotBehaviour _Robot {get;set;}
    private RobotBehaviour Robot {
        get{
            if(_Robot is null) {
                _Robot = GetComponent<RobotBehaviour>();
            }
            return _Robot;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space)){
            Robot.TomarObjetivo();
        }
        
    }
}
