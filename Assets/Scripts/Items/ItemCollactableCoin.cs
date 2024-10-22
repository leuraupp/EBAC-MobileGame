using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    private void Start() {
        CoinsAnimatorManager.Instance.RegisterCoin(this);
    }

    protected override void Collect() {
        OnCollect();
    }

    private void Update() {
        if (collect) {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance) {
                //HideIntens();
                Destroy(gameObject);
            }
        }
    }

    protected override void OnCollect() {
        base.OnCollect();
        collider.enabled = false;
        collect = true;
        //PlayerController.Instance.Bounce(1.2f);

    }
}
