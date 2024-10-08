using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    [Header("Level Pieces")]
    public List<LevelPieceBase> startLevelPieces;
    public List<LevelPieceBase> midleLevelPieces;
    public List<LevelPieceBase> endLevelPieces;
    public int startPiecesPerLevel = 2;
    public int midlePiecesPerLevel = 10;
    public int endPiecesPerLevel = 1;

    //privates
    private int currentLevelIndex = 0;
    private GameObject currentLevel;
    private List<LevelPieceBase> spawnedPieces = new List<LevelPieceBase>();

    private void Awake() {
        CreateLevelWithPieces();
        //SpawnLevels();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            SpawnLevels();
        }

    }

    private void CreateLevelWithPieces() {

        for (int i = 0; i < startPiecesPerLevel; i++) {
            CreateLevelPieces(startLevelPieces);
        }
        for (int i = 0; i < midlePiecesPerLevel; i++) {
            CreateLevelPieces(midleLevelPieces);
        }
        for (int i = 0; i < endPiecesPerLevel; i++) {
            CreateLevelPieces(endLevelPieces);
        }
    }

    private void CreateLevelPieces(List<LevelPieceBase> list) {
        var piece = list[Random.Range(0, list.Count)];
        var newPiece = Instantiate(piece, container);

        if (spawnedPieces.Count > 0) {
            var lastPiece = spawnedPieces[spawnedPieces.Count - 1];
            newPiece.transform.position = lastPiece.endPiece.position;
        }

        spawnedPieces.Add(newPiece);
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
