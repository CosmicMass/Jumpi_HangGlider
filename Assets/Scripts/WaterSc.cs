using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSc : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("JumpiDeltaKanat"))
        {
            CollisionHandler.Instance.WaterCollision();
        }
    }
}
