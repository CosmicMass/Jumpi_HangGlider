using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }
    public void AddScore(int x)
    {
        scoreText.text = x.ToString() + " / 16";
    }
}
