using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpHeight : PowerUpBase
{
    [Header("Power Up Height")]
    public float amountHeight = 2;
    public float animDuration = .1f;
    public DG.Tweening.Ease startEase = DG.Tweening.Ease.Linear;
    public DG.Tweening.Ease endEase = DG.Tweening.Ease.Linear;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Height");
        PlayerController.Instance.ChangeHeight(amountHeight, duration, animDuration, startEase);
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.ResetHeight(animDuration, endEase);
    }
}
