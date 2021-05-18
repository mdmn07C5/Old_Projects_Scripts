using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;

    public delegate int OnPlayerDeath();
    public OnPlayerDeath onPlayerDeath;

    public GameObject obstacleParent;
    [HideInInspector]
    public int totalObstacleCount;
    [HideInInspector]
    public int currentObstacleCount;

    public GameObject winCanvas;
    public GameObject loseCanvas;

    int level;

    public static LevelManager Instance {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        totalObstacleCount = obstacleParent.transform.childCount;
    }

    public void OnLand()
    {
        currentObstacleCount++;
        if (currentObstacleCount == totalObstacleCount)
        {
            //win level
        }
    }
}
