using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("JumpiDeltaKanat"))
        {
            PathFollowerSc.Instance.ChangePathPosition();
        }
    }
}
