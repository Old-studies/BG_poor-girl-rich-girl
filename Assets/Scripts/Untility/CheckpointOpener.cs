using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointOpener : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 axisRotation;
    [SerializeField] float minDistanceToPlayer = 3;

    private bool isClosed = true;

    private void Update()
    {
        if(isClosed && (transform.position - player.position).magnitude < minDistanceToPlayer)
        {
            isClosed = false;
            transform.DORotate(transform.eulerAngles + axisRotation, 0.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear);
        }
        else if (!isClosed && (transform.position - player.position).magnitude > minDistanceToPlayer)
        {
            isClosed = true;
            transform.DORotate(transform.eulerAngles - axisRotation, 0.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear);
        }
    }

}
