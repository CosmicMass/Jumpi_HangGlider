using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class CeilingSc : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("MoDeltaKanat"))
        {
            CollisionHandler.Instance.RoofCollision();
        }
    }
}
