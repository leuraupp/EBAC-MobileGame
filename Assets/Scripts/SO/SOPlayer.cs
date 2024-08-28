using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    [Header("Speed Atributes")]
    public float speed;
    public float speedRun;
    public float forceJump;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Animation Atributes")]
    public float jumpScaleY = 1.1f;
    public float jumpScaleX = 0.7f;
    public float groundedScaleY = 0.8f;
    public float groundedScaleX = 1.2f;
    public float animationDuration = 0.3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;
    public Animator player;
}
