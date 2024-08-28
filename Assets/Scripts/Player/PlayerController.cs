using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //publics
    [Header("Lerp")]
    public float lerpSpeed = 1f;
    public Transform target;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToEndLine = "EndLine";

    public GameObject endGame;

    //privates
    private Vector3 _pos;
    private bool _isDead = false;

    private void Start() {
        _isDead = true;
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
        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag(tagToCheckEnemy)) {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag(tagToEndLine)) {
            EndGame();
        }
    }

    public void EndGame() {
        _isDead = true;
        endGame.SetActive(true);
    }

    public void StartGame() {
        _isDead = false;
    }
}
