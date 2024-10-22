using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public float duration = .2f;
    public MeshRenderer meshRenderer;

    public Color startColor = Color.white;
    public Color endColor;

    private void OnValidate() {
        if (meshRenderer == null) {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    private void Start() {
        endColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

    private void LerpColor() {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(endColor, duration).SetDelay(.5f);
    }
}
