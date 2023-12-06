using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    public static DirectionalArrow Instance;
    public Vector3 targetPosition;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = CircleColor.Instance.colors[0];
    }
    public void ChangeArrowColor()
    {
        this.GetComponent<Renderer>().material.color = CircleColor.Instance.colors[GameManager.Instance.circleIndex];
    }
    private void Update()
    {
        transform.LookAt(targetPosition);
    }
}
