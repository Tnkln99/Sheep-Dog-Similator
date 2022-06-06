using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class GatheringPoint : MonoBehaviour
{
    [SerializeField] private int numberOfSheep;
    private int currentLevel;
    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        Debug.Log(GameController.playerLevel);
    }

    private void Update()
    {
        if (numberOfSheep == 0)
        {
            //TODO: Level finish menu must be integrated here
            
            //here we update savedLevel of the user if necessary
            if (currentLevel >= GameController.playerLevel)
            {
                PlayerPrefs.SetInt("LevelCompleted", currentLevel + 1);
            }
            Application.LoadLevel(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Sheep"))
        {
            Destroy(col.gameObject);
            numberOfSheep--;
            Debug.Log(numberOfSheep);
        }
    }
}
