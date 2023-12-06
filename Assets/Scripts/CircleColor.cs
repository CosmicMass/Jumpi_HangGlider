using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColor : MonoBehaviour
{
    public static CircleColor Instance;

    public List<Color> colors = new List<Color>();

    public List<GameObject> circles;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        circles[0].gameObject.GetComponent<Renderer>().material.color = colors[0];
        DirectionalArrow.Instance.targetPosition = CircleColor.Instance.circles[GameManager.Instance.circleIndex].gameObject.transform.position;

    }
}
