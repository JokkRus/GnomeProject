using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private float _sidewaysMotion = 0.0f;
    public float sidewaysMotion 
    { 
        get => _sidewaysMotion;  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 accel = Input.acceleration; 
        _sidewaysMotion = accel.x;
    }
}
