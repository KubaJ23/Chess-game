using System.Collections.Generic;

namespace Chess
{
    public class King : Piece
    {
        bool check;
        bool checkmate;
        public King(bool white) : base(white)
        {
            check = false;
            checkmate = false;
            if (white)
            {
                this.Image = Chess.Properties.Resources.white_king;
            }
            else
            {
                this.Image = Chess.Properties.Resources.black_king;
            }
        }
        public override void CalculatePossibleMoves(Square[,] grid, int vert, int hor)
        {
            possibleMoves = new List<index_2D>();

            if (Global.CheckForIndex(vert - 1, hor - 1) && (grid[vert - 1, hor - 1].occupiedBypiece == null || grid[vert - 1, hor - 1].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert - 1, hor - 1));
            }

            if (Global.CheckForIndex(vert - 1, hor)
                && (grid[vert - 1, hor].occupiedBypiece == null || grid[vert - 1, hor].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert - 1, hor));
            }

            if (Global.CheckForIndex(vert - 1, hor + 1)
                && (grid[vert - 1, hor + 1].occupiedBypiece == null || grid[vert - 1, hor + 1].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert - 1, hor + 1));
            }

            if (Global.CheckForIndex(vert, hor + 1)
                && (grid[vert, hor + 1].occupiedBypiece == null || grid[vert, hor + 1].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert, hor + 1));
            }

            if (Global.CheckForIndex(vert + 1, hor + 1)
                && (grid[vert + 1, hor + 1].occupiedBypiece == null || grid[vert + 1, hor + 1].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert + 1, hor + 1));
            }

            if (Global.CheckForIndex(vert + 1, hor)
                && (grid[vert + 1, hor].occupiedBypiece == null || grid[vert + 1, hor].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert + 1, hor));
            }

            if (Global.CheckForIndex(vert + 1, hor - 1)
                && (grid[vert + 1, hor - 1].occupiedBypiece == null || grid[vert + 1, hor - 1].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert + 1, hor - 1));
            }

            if (Global.CheckForIndex(vert, hor - 1)
                && (grid[vert, hor - 1].occupiedBypiece == null || grid[vert, hor - 1].occupiedBypiece.white != this.white))
            {
                possibleMoves.Add(new index_2D(vert, hor - 1));
            }
        }
    }
}
