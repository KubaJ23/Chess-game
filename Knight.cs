using System.Collections.Generic;

namespace Chess
{
    public class Knight : Piece
    {
        public Knight(bool white) : base(white)
        {
            if (white)
            {
                this.Image = Chess.Properties.Resources.white_knight;
            }
            else
            {
                this.Image = Chess.Properties.Resources.black_knight;
            }
        }
        public override void CalculatePossibleMoves(Square[,] grid, int vert, int hor)
        {
            possibleMoves = new List<index_2D>();

            if (Global.CheckForIndex(vert - 2, hor - 1))
            {
                possibleMoves.Add(new index_2D(vert - 2, hor - 1));
            }
            if (Global.CheckForIndex(vert - 2, hor + 1))
            {
                possibleMoves.Add(new index_2D(vert - 2, hor + 1));
            }

            if (Global.CheckForIndex(vert - 1, hor + 2))
            {
                possibleMoves.Add(new index_2D(vert - 1, hor + 2));
            }
            if (Global.CheckForIndex(vert + 1, hor + 2))
            {
                possibleMoves.Add(new index_2D(vert + 1, hor + 2));
            }

            if (Global.CheckForIndex(vert + 2, hor + 1))
            {
                possibleMoves.Add(new index_2D(vert + 2, hor + 1));
            }
            if (Global.CheckForIndex(vert + 2, hor - 1))
            {
                possibleMoves.Add(new index_2D(vert + 2, hor - 1));
            }

            if (Global.CheckForIndex(vert + 1, hor - 2))
            {
                possibleMoves.Add(new index_2D(vert + 1, hor - 2));
            }
            if (Global.CheckForIndex(vert - 1, hor - 2))
            {
                possibleMoves.Add(new index_2D(vert - 1, hor - 2));
            }
        }
    }
}
