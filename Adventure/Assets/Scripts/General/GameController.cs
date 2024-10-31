using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public TextMeshProUGUI TextScore;

    public static GameController Instance;
    
    void Start()
    {
        Instance = this;
    }

    public void UpdateTotalScore()
    {
        this.TextScore.text = totalScore.ToString();
    }
    
}
