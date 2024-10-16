using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOLevelPieceBase : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Level Piece Setup")]
    public List<LevelPieceBase> levelPiececStart;
    public List<LevelPieceBase> levelPieceMiddle;
    public List<LevelPieceBase> levelPieceEnd;

    public int piecesStartSize = 3;
    public int piecesMiddleSize = 5;
    public int piecesEndSize = 1;
}
