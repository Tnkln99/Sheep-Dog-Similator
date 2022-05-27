using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FarmAnimal : MonoBehaviour
{
    enum State
    {
        Walking,
        Stop,
        RunAway,
        CollisionEnv
    }

    [SerializeField] private Dog dog;
    
    private Rigidbody2D _rb;

    private State state;
    
    private float stateChangeTime;

    private float directionChangeTime; // That's for walking methode

    private Vector2 movement;
    
    private float speed = 1f;

    private Vector2 collidedEnv;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        state = State.Walking;
        stateChangeTime = Time.time;
        directionChangeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currtime = Time.time;
        
        //if dog gets to close the animals will run away
        if (Vector2.Distance(dog.transform.position, transform.position) < 5f)
        {
            state = State.RunAway;
        }
        else if (currtime - stateChangeTime > 3)
        {
            stateChangeTime = currtime;
            State newState = (State)Random.Range(0, 2);
            state = newState;
        }
        
        //Changing behavior based on state
        switch (state)
        {
            case State.Walking:
                Walking();
                break;
            case State.Stop:
                Stop();
                break;
            case State.RunAway:
                RunAway();
                break;
            case State.CollisionEnv:
                GetAwayFromEnv();
                break;
        }
        //Debug.Log(state);;
    }

    private void FixedUpdate()
    {
        _rb.velocity = movement.normalized * speed;
    }

    void Stop()
    {
        movement = Vector2.zero;
    }

    void Walking()
    {
        float currtime = Time.time;
        if (currtime - directionChangeTime > 2)
        {
            directionChangeTime = currtime;
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }

    void RunAway()
    {
        movement = new Vector2(transform.position.x - dog.transform.position.x, transform.position.y - dog.transform.position.y);
    }
    
    void GetAwayFromEnv()
    {
        movement = new Vector2( collidedEnv.x - transform.position.x, collidedEnv.y - transform.position.y);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("CollisionEnv"))
        {
            collidedEnv = col.transform.position;
            state = State.CollisionEnv;
        }
    }
}
