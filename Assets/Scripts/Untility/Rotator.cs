using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    [SerializeField] float animationDuration = 3f;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 180, 0), animationDuration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
    }

}
