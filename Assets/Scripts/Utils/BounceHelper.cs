using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation Setup")]
    public float scaleTime = 0.2f;
    public float scaleBounce = 1.2f;
    public Ease ease = Ease.OutBack;

    public void Bounce() {
        transform.DOScale(scaleBounce, scaleTime).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
