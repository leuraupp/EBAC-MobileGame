using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollactableBase {
    [Header("Power Up")]
    public float duration = 5f;

    protected override void Collect() {
        base.Collect();
        StartPowerUp();
        PlayerController.Instance.Bounce(1.2f);
    }

    protected virtual void StartPowerUp() {
        Debug.Log("Power Up Started");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp() {
        Debug.Log("Power Up Ended");
    }

}
