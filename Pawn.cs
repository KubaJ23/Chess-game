using System.Collections.Generic;

namespace Chess
{
    public class Pawn : Piece
    {
        public bool moved;
        public Pawn(bool white) : base(white)
        {
            moved = false;

            if (white)
            {
                this.Image = Chess.Properties.Resources.white_pawn;
            }
            else
            {
                this.Image = Chess.Properties.Resources.black_pawn;
            }
        }
        public override void CalculatePossibleMoves(Square[,] grid, int vert, int hor)
        {
            possibleMoves = new List<index_2D>();

            if (this.white)
            {
                if (grid[vert - 1, hor].occupiedBypiece == null && grid[vert - 2, hor].occupiedBypiece == null && !moved)
                {
                    possibleMoves.Add(new index_2D(vert - 2, hor));
                }

                if (grid[vert - 1, hor].occupiedBypiece == null )
                {
                        possibleMoves.Add(new index_2D(vert - 1, hor));
                }

                if (Global.CheckForIndex(vert - 1, hor - 1) && grid[vert - 1, hor - 1].occupiedBypiece != null)
                {
                    //if (this.white != grid[vert - 1, hor - 1].occupiedBypiece.white)
                    //{
                    //    possibleMoves.Add(new index_2D(vert - 1, hor - 1));
                    //}
                    possibleMoves.Add(new index_2D(vert - 1, hor - 1));
                }
                if (Global.CheckForIndex(vert - 1, hor + 1) && grid[vert - 1, hor + 1].occupiedBypiece != null)
                {
                    //if (this.white != grid[vert - 1, hor + 1].occupiedBypiece.white)
                    //{
                    //    possibleMoves.Add(new index_2D(vert - 1, hor + 1));
                    //}
                    possibleMoves.Add(new index_2D(vert - 1, hor + 1));
                }
            }
            else
            {
                if (grid[vert + 1, hor].occupiedBypiece == null && grid[vert + 2, hor].occupiedBypiece == null && !moved)
                {
                    possibleMoves.Add(new index_2D(vert + 2, hor));
                }

                if (grid[vert + 1, hor].occupiedBypiece == null)
                {
                    possibleMoves.Add(new index_2D(vert + 1, hor));
                }

                if (Global.CheckForIndex(vert + 1, hor - 1) && grid[vert + 1, hor - 1].occupiedBypiece != null)
                {
                    //if (this.white != grid[vert + 1, hor - 1].occupiedBypiece.white)
                    //{
                    //    possibleMoves.Add(new index_2D(vert + 1, hor - 1));
                    //}
                    possibleMoves.Add(new index_2D(vert + 1, hor - 1));
                }
                if (Global.CheckForIndex(vert + 1, hor + 1) && grid[vert + 1, hor + 1].occupiedBypiece != null)
                {
                    //if (this.white != grid[vert + 1, hor + 1].occupiedBypiece.white)
                    //{
                    //    possibleMoves.Add(new index_2D(vert + 1, hor + 1));
                    //}
                    possibleMoves.Add(new index_2D(vert + 1, hor + 1));
                }
            }
        }
    }
}
