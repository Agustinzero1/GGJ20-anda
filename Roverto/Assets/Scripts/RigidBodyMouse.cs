using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMouse : MonoBehaviour
{
    public Rigidbody2D MouseCollider;
    public Vector3 Mouse;
    public Vector2 Mouse2D;
    public Vector2 speedVector;
    public float speed;
    public bool MousMove;
    public float MouseTime;
    private float _MouseTime;
    public Camera _cam;
    public Camera cam
    {
        get
        {
            if (_cam == null)
            {
                _cam = Camera.main;
            }
            return _cam;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _MouseTime = MouseTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Mouse = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        speedVector = (Vector2)Mouse - MouseCollider.position;

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                MousMove = true;
                MouseTime = _MouseTime;
            }
        else
            {
                MousMove = false;
                MouseTime -= 1 * Time.deltaTime;
            }
    }

    void FixedUpdate()
    {
        if (MouseTime > 0)
        {
            MouseCollider.MovePosition(MouseCollider.position + speedVector * speed * Time.fixedDeltaTime);
        }
        
    }
}
