using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController> 
{
    //publics
    [Header("Lerp")]
    public float lerpSpeed = 1f;
    public Transform target;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToEndLine = "EndLine";
    public bool invencible = false;
    public GameObject coinCollector;

    [Header("UI")]
    public TextMeshPro uiTextPowerUp;

    public GameObject endGame;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    //privates
    private Vector3 _pos;
    private bool _isDead = false;
    private float _currentSpeed = 1f;
    private Vector3 _startPosition;
    private float animDuration;
    private float _baseSpeedtoAnimation = 7;
    [SerializeField] private BounceHelper _bounceHelper;

    private void Start() {
        _isDead = true;
        _startPosition = transform.position;
        ReserSpeed();
        StartBounce();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead) {
            return;
        }
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag(tagToCheckEnemy)) {
            if (!invencible) {
                MoveBack(collision.transform);
                EndGame(AnimatorManager.AnimatorState.Dead);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag(tagToEndLine)) {
            if (!invencible) {
                EndGame(AnimatorManager.AnimatorState.Idle);
            }
        }
    }

    private void StartBounce() {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, .4f).SetEase(Ease.OutBack).SetDelay(.5f);
    }

    public void Bounce(float scaleBounce) {
        _bounceHelper.Bounce(scaleBounce);
    }

    private void MoveBack(Transform t) {
        t.DOMoveZ(1f, .3f).SetRelative();
    }

    public void EndGame(AnimatorManager.AnimatorState animatorState = AnimatorManager.AnimatorState.Idle) {
        _isDead = true;
        endGame.SetActive(true);
        animatorManager.Play(animatorState);
    }

    public void StartGame() {
        _isDead = false;
        transform.position = _startPosition;
        animatorManager.Play(AnimatorManager.AnimatorState.Run, _currentSpeed /  _baseSpeedtoAnimation);
    }

    public void RestartGame() {
        _isDead = false;
        transform.position = _startPosition;
        endGame.SetActive(false);
        LevelManager.Instance.RestartLevel();
        animatorManager.Play(AnimatorManager.AnimatorState.Run, _currentSpeed / _baseSpeedtoAnimation);
    }

    public void SetPowerUpText(string s) {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f) {
        _currentSpeed = f;
    }

    public void ReserSpeed() {
        _currentSpeed = speed;
    }

    public void setInvencible(bool b) {
        invencible = b;
    }

    public void ChangeHeight(float amountHeight, float duration, float animDuration, Ease ease) {
        this.animDuration = animDuration;
        transform.DOMoveY(_startPosition.y + amountHeight, this.animDuration).SetEase(ease);
    }

    public void ResetHeight(float animDuration, Ease ease) {
        transform.DOMoveY(_startPosition.y, animDuration).SetEase(ease);
    }

    public void CoinCollectorSize(float sizeAmount) {
        coinCollector.transform.localScale = Vector3.one * sizeAmount;
    }
}
