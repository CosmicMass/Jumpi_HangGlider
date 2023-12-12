using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("JumpiDeltaKanat"))
        {
            CollisionHandler.Instance.LeftCollision();
        }
    }
}
