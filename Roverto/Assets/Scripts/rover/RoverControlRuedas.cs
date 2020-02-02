using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverControlRuedas : MonoBehaviour
{
public WheelJoint2D Rueda1;
public WheelJoint2D Rueda2;
public WheelJoint2D Rueda3;

public float MaxSpeed;
public float Speed;
public float CurrentSpeed;
public float Aceleracton;
public float Break;

public string AxisHorizontalMov;
public JointMotor2D m1;
public JointMotor2D m2;
public JointMotor2D m3;

    // Start is called before the first frame update
    void Start()
    {

        m1 = Rueda1.motor;
        m2 = Rueda2.motor;
        m3 = Rueda3.motor;

    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(AxisHorizontalMov + " : " + Input.GetAxis(AxisHorizontalMov));
                    
        m1.motorSpeed = CurrentSpeed;
        Rueda1.motor = m1;
            
        m2.motorSpeed = CurrentSpeed;
        Rueda2.motor = m2;

        m3.motorSpeed = CurrentSpeed;
        Rueda3.motor = m3;

        CurrentSpeed = -1 * Input.GetAxis(AxisHorizontalMov) * Speed * Time.deltaTime;

    }
}
