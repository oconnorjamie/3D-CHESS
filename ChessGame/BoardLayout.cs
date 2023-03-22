using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Board/Layout")]
public class BoardLayout : ScriptableObject
{
    [Serializable]
    private class BoardSquareSetup 
    {
        public Vector2Int position;
        public PieceType pieceType;
        public TeamColor teamColor;
    }
    [SerializeField] private BoardSquareSetup[] BoardSquares;

    public int GetNumPieces()
    {
        return BoardSquares.Length;
    }

    public Vector2Int GetCoordsAtIndex(int index)
    {
        if (BoardSquares.Length <= index)
        {
            Debug.LogError("Index is outside of range");
            return new Vector2Int(-1, -1);
        }
        return new Vector2Int(BoardSquares[index].position.x - 1, BoardSquares[index].position.y - 1);
    }
    
    public string GetPieceNameOfSquare(int index)
    {
        if (BoardSquares.Length <= index)
        {
            Debug.LogError("Index is outside of range");
            return "";
        }
        return BoardSquares[index].pieceType.ToString();
    }
    public TeamColor GetTeamColorOfSquare(int index)
    {
        if (BoardSquares.Length <= index)
        {
            Debug.LogError("Index is outside of range");
            return TeamColor.Black;
        }
        return BoardSquares[index].teamColor;
    }
}
