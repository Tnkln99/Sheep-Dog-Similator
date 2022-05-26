using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 movement { get; set; }
    private Rigidbody2D rb;

    [SerializeField] private MobileJoyStick _joyStick;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        rb = GetComponent<Rigidbody2D>();

    }
    
    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(_joyStick.offset.x * speed, _joyStick.offset.y * speed);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;
    }


    private void Move(Vector2 input)
    {
        
    }
    
}
