using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private float walkSpeed = 2f;
    private float runSpeed = 5f;
    
    
    private Vector2 movement { get; set; }
    private Rigidbody2D _rb;

    [SerializeField] private MobileJoyStick _joyStick;
    [SerializeField] private ButtonRunFast _buttonRunFast;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(_buttonRunFast.isFast)
            movement = _joyStick.offset.normalized * runSpeed;
        else 
            movement = _joyStick.offset.normalized * walkSpeed;
    }

    private void FixedUpdate()
    {
        _rb.velocity = movement;
    }
}
