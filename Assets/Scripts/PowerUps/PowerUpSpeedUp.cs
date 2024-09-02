using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Speed Up")]
    public float speedMultiplier = 2f;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(speedMultiplier);
        PlayerController.Instance.SetPowerUpText("Speed Up");
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.ReserSpeed();
        PlayerController.Instance.SetPowerUpText("");
    }
}
