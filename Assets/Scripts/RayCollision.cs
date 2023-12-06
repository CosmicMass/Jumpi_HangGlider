using UnityEngine;
using DG.Tweening;

public class RayCollision : MonoBehaviour
{
    Rigidbody rb;

    public GameObject currentHitObject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    public LayerMask layerMask2;

    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        origin = transform.position;
        direction = transform.forward;
        RayIslandCollision();
        RayBordersCollision();
    }

    private void RayBordersCollision()
    {
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask2, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            DeltaController.Instance.joystick.myOnDrag = false;
            transform.DORotate(new Vector3(0, 120, 0), 80f * Time.fixedDeltaTime, RotateMode.WorldAxisAdd);
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("memo");
    }

    private void RayIslandCollision()
    {
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            rb.transform.DOLocalMoveY(transform.localPosition.y + 50f, 40f * Time.fixedDeltaTime);
        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
