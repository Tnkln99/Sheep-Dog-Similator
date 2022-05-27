using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringPoint : MonoBehaviour
{
    [SerializeField] private int numberOfAnimals;

    private void Update()
    {
        if (numberOfAnimals <= 0)
        {
            Debug.Log("You won!");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Sheep"))
        {
            Destroy(col.gameObject);
            numberOfAnimals--;
        }
    }
}
