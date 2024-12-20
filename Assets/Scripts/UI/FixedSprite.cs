using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSprite : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 initialPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        initialPosition = transform.position;
    }

    void LateUpdate()
    {
        transform.LookAt(cameraTransform);
        transform.position = initialPosition;
    }
}
