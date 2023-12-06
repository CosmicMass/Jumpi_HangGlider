using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int circleIndex;

    public Transform confettiTransform;
    public List<ParticleSystem> Confetti;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach (Transform item in confettiTransform)
        {
            Confetti.Add(item.GetComponent<ParticleSystem>());
        }
    }
    public void ConfettiPlay()
    {
        for (int i = 0; i < Confetti.Count; i++)
        {
            Confetti[i].Play();
        }
    }

    private void OnApplicationQuit()
    {
        circleIndex = 0;
    }
}
