using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointOpener : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 axisRotation;
     float minDistanceToPlayer = 3;


    private bool isRotated = false;

    private void Start()
    {

    }

    private void Update()
    {
        if(!isRotated && (transform.position - player.position).magnitude < minDistanceToPlayer)
        {
            isRotated = true;
            transform.DORotate(transform.eulerAngles + axisRotation, 0.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear);
        }
    }

}
