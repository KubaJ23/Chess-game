using System.Collections.Generic;

namespace Chess
{
    public class Bishop : Piece
    {
        public Bishop(bool white) : base(white)
        {
            if (white)
            {
                this.Image = Chess.Properties.Resources.white_bishop;
            }
            else
            {
                this.Image = Chess.Properties.Resources.black_bishop;
            }
        }
        public override void CalculatePossibleMoves(Square[,] grid, int vert, int hor)
        {
            possibleMoves = new List<index_2D>();

            bool stop = false;
            int temp_vert = vert;
            int temp_hor = hor;

            do
            {
                temp_vert -= 1;
                temp_hor += 1;

                if (Global.CheckForIndex(temp_vert, temp_hor))
                {
                    if (grid[temp_vert, temp_hor].occupiedBypiece != null)
                    {
                            possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                            stop = true;
                    }
                    else
                    {
                        possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                    }
                }
                else
                {
                    stop = true;
                }
            } while (!stop);

            stop = false;
            temp_vert = vert;
            temp_hor = hor;
            do
            {
                temp_vert += 1;
                temp_hor += 1;

                if (Global.CheckForIndex(temp_vert, temp_hor))
                {
                    if (grid[temp_vert, temp_hor].occupiedBypiece != null)
                    {
                            possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                            stop = true;
                    }
                    else
                    {
                        possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                    }
                }
                else
                {
                    stop = true;
                }
            } while (!stop);

            stop = false;
            temp_vert = vert;
            temp_hor = hor;
            do
            {
                temp_vert += 1;
                temp_hor -= 1;

                if (Global.CheckForIndex(temp_vert, temp_hor))
                {
                    if (grid[temp_vert, temp_hor].occupiedBypiece != null)
                    {
                            possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                            stop = true;
                    }
                    else
                    {
                        possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                    }
                }
                else
                {
                    stop = true;
                }
            } while (!stop);

            stop = false;
            temp_vert = vert;
            temp_hor = hor;
            do
            {
                temp_vert -= 1;
                temp_hor -= 1;

                if (Global.CheckForIndex(temp_vert, temp_hor))
                {
                    if (grid[temp_vert, temp_hor].occupiedBypiece != null)
                    {
                            possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                            stop = true;
                    }
                    else
                    {
                        possibleMoves.Add(new index_2D(temp_vert, temp_hor));
                    }
                }
                else
                {
                    stop = true;
                }
            } while (!stop);
        }
    }
}
