using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    void levelSelect(int index)
    {
        if(index <= GameController.playerLevel)
        {
            Application.LoadLevel(index + 1);
        }
        else
        {
            Debug.Log("You need to beat level " + GameController.playerLevel + " before you can play level " + index);
        }
    }
}
