using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private bool invert;
    
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (invert)
        {
            Vector3 dicToCamera = (cameraTransform.position - transform.position).normalized;
            transform.LookAt(transform.position + dicToCamera * -1);
        }
        else
        {
            transform.LookAt(cameraTransform);
        }
    }
}
