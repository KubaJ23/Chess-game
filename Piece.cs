using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public abstract class Piece
    {
        public bool alive;
        public bool white;
        public Image Image;
        public List<index_2D> possibleMoves;

        public Piece(bool white)
        {
            alive = true;
            this.white = white;
            possibleMoves = new List<index_2D>();
        }
        public void remove()
        {
            alive = false;
        }
        public virtual void CalculatePossibleMoves(Square[,] grid, int vert, int hor)
        {

        }
    }
}
