using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask targetLayer;

    public Transform DetectTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
        if (hits.Length > 0)
        {
            return hits[0].transform;
        }
        return null;
    }
}