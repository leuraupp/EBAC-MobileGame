using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("Coins Collector")]
    public float sizeAmount = 7f;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Coins");
        PlayerController.Instance.CoinCollectorSize(sizeAmount);
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.CoinCollectorSize(1);
    }

}
