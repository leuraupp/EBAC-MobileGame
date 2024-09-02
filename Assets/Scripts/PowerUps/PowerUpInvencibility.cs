using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencibility : PowerUpBase
{
    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.setInvencible(true);
        PlayerController.Instance.SetPowerUpText("Invencibility");
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.setInvencible(false);
        PlayerController.Instance.SetPowerUpText("");
    }
}
