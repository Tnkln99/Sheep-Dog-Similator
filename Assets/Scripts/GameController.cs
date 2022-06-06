using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int playerLevel;
    private List<float> levelTimes;
    private void Start()
    {
        playerLevel = PlayerPrefs.GetInt("LevelCompleted", 1);
    }
}
