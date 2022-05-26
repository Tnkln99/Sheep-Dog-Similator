using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField]private Dog _Dog;

    public float smoothing;
    public Vector2 maxPos;
    public Vector2 minPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_Dog.transform.position.x > transform.position.x + 8.5f)
        {
            movement = new Vector3(_Dog.transform.position.x - 8.5f, transform.position.y, transform.position.z);
        }
        else if(_Dog.transform.position.x < transform.position.x - 8.5f)
        {
            movement = new Vector3(_Dog.transform.position.x + 8.5f, transform.position.y, transform.position.z);
        }

        if (_Dog.transform.position.y > transform.position.y + 3.5f)
        {
            movement = new Vector3(transform.position.x, _Dog.transform.position.y - 3.5f, transform.position.z);
        }
        else if (_Dog.transform.position.y < transform.position.y - 3.5f)
        {
            movement = new Vector3(transform.position.x, _Dog.transform.position.y + 3.5f, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if(transform.position != movement)
        {
            Vector3 targetPos = new Vector3 (movement.x,movement.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x,minPos.x,maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y,minPos.y,maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
        
    }
}
