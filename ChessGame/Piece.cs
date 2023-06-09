using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(IObjectTweener))]
[RequireComponent(typeof(MaterialSetter))]
public abstract class Piece : MonoBehaviour
{
    private MaterialSetter materialSetter;
    public Board board { protected get; set; }
    public Vector2Int occupiedSquare { get; set; }
    public TeamColor team { get; set; }
    public bool hasMoved { get; private set; }
    public List<Vector2Int> availableMoves;

    private IObjectTweener tweener;
    public abstract List<Vector2Int> SelectAvailableSquares();
    private void Awake()
    {
        availableMoves = new List<Vector2Int>();
        tweener = GetComponent<IObjectTweener>();
        materialSetter = GetComponent<MaterialSetter>();
        hasMoved = false;
    }
    public void setMaterial(Material material)
    {
        if (materialSetter == null)
            materialSetter = GetComponent<MaterialSetter>();
        materialSetter.SetSingleMaterial(material);
    }
    public bool sameTeam(Piece piece)
    {
        return team == piece.team;
    }
    public bool canMoveTo(Vector2Int coords)
    {
        return availableMoves.Contains(coords);
    }
    public virtual void movePiece(Vector2Int coords)
    {

    }
    public void TryToAddMove(Vector2Int coords)
    {
        availableMoves.Add(coords);
    }
    public void SetData(Vector2Int coords, TeamColor team, Board board)
    {
        this.team = team;
        occupiedSquare = coords;
        this.board = board;
        transform.position = board.CalculatePositonFromCoords(coords);
    }
}

