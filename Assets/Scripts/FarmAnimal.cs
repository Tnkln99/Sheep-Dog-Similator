using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimal : MonoBehaviour
{
    enum State
    {
        Walking,
        Stop,
        RunAway
    }

    [SerializeField] private Dog dog;

    private State state;
    
    private float stateChangeTime;

    private float directionChangeTime; // That's for walking methode

    private Vector2 movement;
    
    private float speed = 1f;
    
    private float runAwaySpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Walking;
        stateChangeTime = Time.time;
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
        }
        
        Debug.Log(state);
    }
    
    void Walking()
    {
        float currtime = Time.time;
        if (currtime - directionChangeTime > 2)
        {
            directionChangeTime = currtime;
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        transform.Translate(movement.normalized * speed * Time.deltaTime);
    }

    void RunAway()
    {
        movement = new Vector2(transform.position.x - dog.transform.position.x, transform.position.y - dog.transform.position.y);
        transform.Translate(movement.normalized * runAwaySpeed * Time.deltaTime);
    }
    //To implement stop animation later
    void Stop()
    {
        
    }
}
