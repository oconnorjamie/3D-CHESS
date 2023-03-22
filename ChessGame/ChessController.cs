using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PieceCreator))]
public class ChessController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BoardLayout startingBoardLayout;
    [SerializeField] private Board board;

    private PieceCreator pieceCreator;
    private ChessPlayer whitePlayer;
    private ChessPlayer blackPlayer;
    private ChessPlayer activePlayer;

    private void Awake()
    {
        SetDependencies();
        CreatePlayers();
    }

    private void CreatePlayers()
    {
        whitePlayer = new ChessPlayer(TeamColor.White, board);
        blackPlayer = new ChessPlayer(TeamColor.Black, board);
    }

    private void SetDependencies()
    {
        pieceCreator = GetComponent<PieceCreator>();
    }

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreatePiecesFromLayout(startingBoardLayout);
        activePlayer = whitePlayer;
        GenerateAllPossibleMoves(activePlayer);
    }

    private void GenerateAllPossibleMoves(ChessPlayer activePlayer)
    {
        activePlayer.GenerateAllMoves();
    }

    private void CreatePiecesFromLayout(BoardLayout board)
    {
        for (int i = 0; i < board.GetNumPieces(); i++)
        {
            Vector2Int SquareCoords = board.GetCoordsAtIndex(i);
            TeamColor team = board.GetTeamColorOfSquare(i);
            string typeName = board.GetPieceNameOfSquare(i);

            Type type = Type.GetType(typeName);
            Create(SquareCoords, team, type);
        }
    }

    private void Create(Vector2Int squareCoords, TeamColor team ,Type type)
    {
        Debug.Log("OK");
        Piece newPiece = pieceCreator.CreatePiece(type).GetComponent<Piece>();
        newPiece.SetData(squareCoords, team, board);

        Material teamMaterial = pieceCreator.GetTeamMaterial(team);
        newPiece.setMaterial(teamMaterial);
    }
}
