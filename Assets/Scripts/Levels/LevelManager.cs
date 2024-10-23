using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;

    public List<GameObject> levels;

    [Header("Level Pieces")]
    public List<SOLevelPieceBase> piecesSetup;

    //privates
    private int currentLevelIndex = 0;
    private GameObject currentLevel;
    [SerializeField] private List<LevelPieceBase> spawnedPieces = new List<LevelPieceBase>();
    private SOLevelPieceBase currentPiecesSetup;

    [Header("Animation Setup")]
    public float scaleTime = 0.2f;
    public float timeBetweenPieces = 0.1f;
    public Ease ease = Ease.OutBack;

    private void Start() {
        CreateLevelWithPieces();
        //SpawnLevels();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            // SpawnLevels();
            CreateLevelWithPieces();
        }

    }

    public void RestartLevel() {
        CreateLevelWithPieces();
    }

    private void CreateLevelWithPieces() {
        CleanSpawnedPieces();

        if (currentPiecesSetup != null) {
            currentLevelIndex++;

            if (currentLevelIndex >= piecesSetup.Count) {
                ResetLevelIndex();
            }
        }

        currentPiecesSetup = piecesSetup[currentLevelIndex];

        for (int i = 0; i < currentPiecesSetup.piecesStartSize; i++) {
            CreateLevelPieces(currentPiecesSetup.levelPiececStart);
        }

        for (int i = 0; i < currentPiecesSetup.piecesMiddleSize; i++) {
            CreateLevelPieces(currentPiecesSetup.levelPieceMiddle);
        }

        for (int i = 0; i < currentPiecesSetup.piecesEndSize; i++) {
            CreateLevelPieces(currentPiecesSetup.levelPieceEnd);
        }

        ColorManager.Instance.ChangeColorByType(currentPiecesSetup.artType);

        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime() {
        foreach (var piece in spawnedPieces) {
            piece.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < spawnedPieces.Count; i++) {
            spawnedPieces[i].transform.DOScale(Vector3.one, scaleTime).SetEase(ease);
            yield return new WaitForSeconds(timeBetweenPieces);
        }

        CoinsAnimatorManager.Instance.CleanCoinsList();
        CoinsAnimatorManager.Instance.StartAnimation();
    }

    private void CreateLevelPieces(List<LevelPieceBase> list) {
        var piece = list[Random.Range(0, list.Count)];
        var newPiece = Instantiate(piece, container);

        if (spawnedPieces.Count > 0) {
            var lastPiece = spawnedPieces[spawnedPieces.Count - 1];
            Debug.Log(lastPiece.endPiece.position);
            newPiece.transform.position = lastPiece.endPiece.position;
        } else {
            newPiece.transform.position = Vector3.zero;
        }

        foreach (var p in newPiece.GetComponentsInChildren<ArtPiece>()) {
            p.ChangePiece(ArtManager.Instance.GetSetupByTaype(currentPiecesSetup.artType).artObject);
        }

        spawnedPieces.Add(newPiece);
    }

    private void CleanSpawnedPieces() {
        for (int i = spawnedPieces.Count - 1; i >= 0; i--) {
            Destroy(spawnedPieces[i].gameObject);
        }
        spawnedPieces.Clear();
    }

    private void SpawnLevels() {
        if (currentLevel != null) {
            Destroy(currentLevel);
            currentLevelIndex++;

            if (currentLevelIndex >= levels.Count) {
                ResetLevelIndex();
            }
        }

        currentLevel = Instantiate(levels[currentLevelIndex], container);
        currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex() {
        currentLevelIndex = 0;
    }
}
