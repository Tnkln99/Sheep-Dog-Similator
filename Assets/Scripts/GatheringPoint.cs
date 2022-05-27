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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Sheep"))
        {
            Debug.Log("Sheep entered");
            Destroy(col.gameObject);
            numberOfAnimals--;
        }
    }
}
