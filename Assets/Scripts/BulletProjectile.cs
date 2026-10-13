using System;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private Transform bulletHitVfxPrefab;
    private Vector3 targetPosition;
    
    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        
        float distanceBeforeMoving = Vector3.Distance(transform.position, targetPosition);
        float moveSpeed = 200f;
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        float distanceAftereMoving = Vector3.Distance(transform.position, targetPosition);


        if (distanceBeforeMoving < distanceAftereMoving)
        {
            transform.position = targetPosition;
            
            trailRenderer.transform.parent = null;
            Destroy(gameObject);
            
            Instantiate(bulletHitVfxPrefab, targetPosition, Quaternion.identity);
        }
    }
}
 