using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    public TextMeshProUGUI levelDisplay;
    public Image fill;

    private void Start()
    {
        SetupLevelDisplay();    
    }

    void SetupLevelDisplay()
    {

    }

    void UpdateDisplay()
    {
        fill.fillAmount = LevelManager.Instance.currentObstacleCount / (float)LevelManager.Instance.totalObstacleCount;
    }
}
