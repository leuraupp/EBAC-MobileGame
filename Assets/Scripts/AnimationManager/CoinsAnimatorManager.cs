using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Xml.Serialization;
using System.Linq;

public class CoinsAnimatorManager : Singleton<CoinsAnimatorManager>
{

    [Header("Coins List")]
    public List<ItemCollactableCoin> coins;

    [Header("Animation Setup")]
    public float scaleTime = 0.2f;
    public float timeBetweenCoins = 0.1f;
    public Ease ease = Ease.OutBack;

    // Start is called before the first frame update
    void Start()
    {
        coins = new List<ItemCollactableCoin>();
    }

    public void RegisterCoin(ItemCollactableCoin coin) {
        if (!coins.Contains(coin)) {
            coins.Add(coin);
            coin.transform.localScale = Vector3.zero;
        }
        Debug.Log("Coin registered");
    }

    public void CleanCoinsList() {
        coins.RemoveAll(coin => coin == null);
    }

    public void StartAnimation() {
        StartCoroutine(ScaleCoinByTime());
    }

    IEnumerator ScaleCoinByTime() {
        Sort();

        if (coins != null) {
            for (int i = 0; i < coins.Count; i++) {
                coins[i].transform.DOScale(Vector3.one, scaleTime).SetEase(ease);
                yield return new WaitForSeconds(timeBetweenCoins);
            }
        }
    }

    private void Sort() {
        if (coins != null) {
            coins.RemoveAll(coin => coin == null);
            coins = coins.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
        }
    }
}
