using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class PlayerController : Singleton<PlayerController> 
{
    //publics
    [Header("Lerp")]
    public float lerpSpeed = 1f;
    public Transform target;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToEndLine = "EndLine";
    public bool _invencible = false;

    public GameObject endGame;

    //privates
    private Vector3 _pos;
    private bool _isDead = false;
    private float _currentSpeed = 1f;

    private void Start() {
        _isDead = true;
        ReserSpeed();
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
            if (!_invencible) {
                EndGame();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag(tagToEndLine)) {
            if (!_invencible) {
                EndGame();
            }
        }
    }

    public void EndGame() {
        _isDead = true;
        endGame.SetActive(true);
    }

    public void StartGame() {
        _isDead = false;
    }

    public void SetPowerUpText(string s) {
        //uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f) {
        _currentSpeed = f;
    }

    public void ReserSpeed() {
        _currentSpeed = speed;
    }

    public void setInvencible(bool b) {
        _invencible = b;
    }
}
