using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public class Square : PictureBox
    {
        public Piece occupiedBypiece;
        public int vertical_index;
        public int horizontal_index;
        public bool white;
        public Square(int xpos, int ypos, int vert_ind, int hor_ind, int size, bool white)
        {
            vertical_index = vert_ind;
            horizontal_index = hor_ind;

            this.white = white;
            occupiedBypiece = null;
            this.Location = new Point(xpos, ypos);
            this.Size = new Size(size, size);

            if (white)
            {
                this.BackColor = Color.FromArgb(238, 238, 210);
            }
            else
            {
                this.BackColor = Color.FromArgb(118, 150, 86);
            }

            this.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public void TakePiece(Piece newpiece)
        {
            if (newpiece != null)
            {
                this.occupiedBypiece = newpiece;
                this.Image = newpiece.Image;
            }
            else
            {
                RemovePiece();
            }
        }
        public Piece RemovePiece()
        {
            Piece tempPiece = this.occupiedBypiece;
            occupiedBypiece = null;
            this.Image = null;
            return tempPiece;
        }
    }
}
