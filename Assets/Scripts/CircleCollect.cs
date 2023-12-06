using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CircleCollect : MonoBehaviour
{
    //public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("MoDeltaKanat"))
        {
            GameManager.Instance.ConfettiPlay();
            GameManager.Instance.circleIndex++;
            ScoreSystem.Instance.AddScore(GameManager.Instance.circleIndex);
            Debug.Log(GameManager.Instance.circleIndex);
            gameObject.SetActive(false);
            DirectionalArrow.Instance.ChangeArrowColor();
            CircleColor.Instance.circles[GameManager.Instance.circleIndex].gameObject.SetActive(true);
            CircleColor.Instance.circles[GameManager.Instance.circleIndex].gameObject.GetComponent<Renderer>().material.color = CircleColor.Instance.colors[GameManager.Instance.circleIndex];
            DirectionalArrow.Instance.targetPosition = CircleColor.Instance.circles[GameManager.Instance.circleIndex].gameObject.transform.position;
        }
    }
}

