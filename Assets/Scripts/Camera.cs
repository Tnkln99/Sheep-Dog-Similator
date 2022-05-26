using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField]private Dog _Dog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_Dog.transform.position.x > transform.position.x + 8.5f)
        {
            transform.position = new Vector3(_Dog.transform.position.x - 8.5f, transform.position.y, transform.position.z);
        }
        else if(_Dog.transform.position.x < transform.position.x - 8.5f)
        {
            transform.position = new Vector3(_Dog.transform.position.x + 8.5f, transform.position.y, transform.position.z);
        }

        if (_Dog.transform.position.y > transform.position.y + 3.5f)
        {
            transform.position = new Vector3(transform.position.x, _Dog.transform.position.y - 3.5f, transform.position.z);
        }
        else if (_Dog.transform.position.y < transform.position.y - 3.5f)
        {
            transform.position = new Vector3(transform.position.x, _Dog.transform.position.y + 3.5f, transform.position.z);
        }
        //transform.position = new Vector3(_Dog.transform.position.x, _Dog.transform.position.y, -10);
    }
}
