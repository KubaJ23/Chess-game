using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public class ChessGame : Form
    {
        int square_size = 100;
        int gapsize = 30;
        Square[,] chessBoard;
        index_2D selectedPiece;
        Timer timer;
        Graphics g;
        bool white_PlayerTurn;
        Button checkmatebtn;
        Button Surrenderbtn;

        Piece replaced_Piece;

        bool check;

        index_2D whiteKing_index = new index_2D(7, 4);
        index_2D blackKing_index = new index_2D(0, 4);

        List<index_2D> PossibleAttacksList_White;
        List<index_2D> PossibleAttacksList_Black;

        public ChessGame()
        {
            this.ClientSize = new Size(8 * square_size + gapsize * 2 + 150, 8 * square_size + gapsize * 2);
            this.CenterToScreen();
            this.BackColor = Color.DimGray;
            white_PlayerTurn = true;

            checkmatebtn = new Button();
            checkmatebtn.Size = new Size(170,200 );
            checkmatebtn.Text = "Admit Checkmate";
            checkmatebtn.Location = new Point(8 * square_size + gapsize * 2 - 25, gapsize);
            checkmatebtn.BackColor = Color.White;
            checkmatebtn.Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);


            Surrenderbtn = new Button();
            Surrenderbtn.BackColor = Color.White;
            Surrenderbtn.Size = new Size(170, 200);
            Surrenderbtn.Location = new Point(8 * square_size + gapsize * 2 - 25, gapsize + 205);
            Surrenderbtn.Text = "Surrender & Leave";
            Surrenderbtn.Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
            Surrenderbtn.Enabled = false;

            checkmatebtn.Click += new EventHandler(Checkmatebtn_Click);
            Surrenderbtn.Click += new EventHandler(Surrenderbtn_Click);

            PossibleAttacksList_White = new List<index_2D>();
            PossibleAttacksList_Black = new List<index_2D>();

            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 20;
            g = CreateGraphics();

            this.Load += new System.EventHandler(this.ChessGame_Load);
        }
        private void ChessGame_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            CreateBoard();
            SetGame();

            this.Controls.Add(checkmatebtn);
            this.Controls.Add(Surrenderbtn);

            foreach (var item in chessBoard)
            {
                item.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Square_MouseDown);
            }

        }
        public void Checkmatebtn_Click(object sender, EventArgs e)
        {
            if (Surrenderbtn.Enabled)
            {
                Surrenderbtn.Enabled ^= true;
            }
            else
            {
                MessageBox.Show("Are you sure you want to surrender?");
                Surrenderbtn.Enabled ^= true;
            }
        }
        public void Surrenderbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Square_MouseDown(object sender, EventArgs e)
        {
            Square clickedSquare = (Square)sender;
            //timer.Enabled = true;

            //clear previous colours
            ClearBoard();

            //select the clicked square and calc all possible moves and color possible moves
            if (clickedSquare.occupiedBypiece != null && clickedSquare.occupiedBypiece.white == white_PlayerTurn)
            {
                SelectSquare(clickedSquare);
            }
            // if the square is a possible move of the selected piece and there is a piece selected, then move the selected piece to clicked square
            else
            {
                if (selectedPiece.vertical_pos != -1
                    && chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].occupiedBypiece.possibleMoves.Contains(new index_2D(clickedSquare.vertical_index, clickedSquare.horizontal_index))
                    && (clickedSquare.occupiedBypiece == null || clickedSquare.occupiedBypiece.white != chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].occupiedBypiece.white))
                {
                    MovePiece(ref clickedSquare);
                    CalculateAllPossibleMoves();

                    if (white_PlayerTurn)
                    {
                        if (PossibleAttacksList_Black.Contains(whiteKing_index))
                        {
                            chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].TakePiece(clickedSquare.RemovePiece());
                            clickedSquare.TakePiece(replaced_Piece);
                            white_PlayerTurn ^= true;
                        }
                    }
                    else
                    {
                        if (PossibleAttacksList_White.Contains(blackKing_index))
                        {
                            chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].TakePiece(clickedSquare.RemovePiece());
                            clickedSquare.TakePiece(replaced_Piece);
                            white_PlayerTurn ^= true;
                        }
                    }
                    //change turn
                    white_PlayerTurn ^= true;
                }
               
                
                // reset selected piece after a moved piece
                selectedPiece = new index_2D(-1, -1);
            }

            
        }

        private void MovePiece(ref Square clickedSquare)
        {
            if (chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].occupiedBypiece.GetType() == new Pawn(true).GetType())
            {
                Pawn tempPawn = (Pawn)chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].occupiedBypiece;
                tempPawn.moved = true;
                chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].TakePiece(tempPawn);
            }
            if (chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].occupiedBypiece.GetType() == new King(true).GetType())
            {
                if (white_PlayerTurn)
                {
                    whiteKing_index = new index_2D(clickedSquare.vertical_index, clickedSquare.horizontal_index);
                }
                else
                {
                    blackKing_index = new index_2D(clickedSquare.vertical_index, clickedSquare.horizontal_index);
                }
            }
            replaced_Piece = clickedSquare.occupiedBypiece;
            clickedSquare.TakePiece(chessBoard[selectedPiece.vertical_pos, selectedPiece.horizontal_pos].RemovePiece());
        }

        private void ClearBoard()
        {
            foreach (var item in chessBoard)
            {
                if (item.white)
                {
                    item.BackColor = Color.FromArgb(238, 238, 210);
                }
                else
                {
                    item.BackColor = Color.FromArgb(118, 150, 86);
                }
            }
        }

        private void SelectSquare(Square clickedSquare)
        {
            selectedPiece = new index_2D(clickedSquare.vertical_index, clickedSquare.horizontal_index);

            clickedSquare.occupiedBypiece.CalculatePossibleMoves(chessBoard, clickedSquare.vertical_index, clickedSquare.horizontal_index);
            foreach (var item in clickedSquare.occupiedBypiece.possibleMoves)
            {
                if (chessBoard[item.vertical_pos, item.horizontal_pos].occupiedBypiece == null || chessBoard[item.vertical_pos, item.horizontal_pos].occupiedBypiece.white != clickedSquare.occupiedBypiece.white)
                {
                    chessBoard[item.vertical_pos, item.horizontal_pos].BackColor = Color.Red;
                }
            }
        }

        public void SetGame()
        {
            //setting up pawns for both colours
            for (int i = 0; i < chessBoard.GetLength(1); i++)
            {
                chessBoard[6, i].TakePiece(new Pawn(true));
                chessBoard[1, i].TakePiece(new Pawn(false));
            }

            //setting white piesces on the bottom of board
            chessBoard[7,0].TakePiece(new Rook(true));
            chessBoard[7,7].TakePiece(new Rook(true));
                          
            chessBoard[7,1].TakePiece(new Knight(true));
            chessBoard[7,6].TakePiece(new Knight(true));
                         
            chessBoard[7,2].TakePiece(new Bishop(true));
            chessBoard[7,5].TakePiece(new Bishop(true));
                          
            chessBoard[7,3].TakePiece(new Queen(true));
            chessBoard[7,4].TakePiece(new King(true));

            //setting black pieces on top of board
            chessBoard[0,0].TakePiece(new Rook(false));
            chessBoard[0,7].TakePiece(new Rook(false));
                        
            chessBoard[0,1].TakePiece(new Knight(false));
            chessBoard[0,6].TakePiece(new Knight(false));
                            
            chessBoard[0,2].TakePiece(new Bishop(false));
            chessBoard[0,5].TakePiece(new Bishop(false));
                          
            chessBoard[0,3].TakePiece(new Queen(false));
            chessBoard[0,4].TakePiece(new King(false));

        }
        public void CreateBoard()
        {
            chessBoard = new Square[8, 8];
            int colournum = 0;
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                for (int k = 0; k < chessBoard.GetLength(1); k++)
                {
                    chessBoard[i, k] = new Square(gapsize + k * square_size, gapsize + i * square_size,i,k, square_size, colournum % 2 == 0);
                    this.Controls.Add(chessBoard[i, k]);
                    colournum++;
                }
                colournum++;
            }
        }
        public void CalculateAllPossibleMoves()
        {
            foreach (var item in chessBoard)
            {
                if (item.occupiedBypiece != null)
                {
                        item.occupiedBypiece.CalculatePossibleMoves(chessBoard, item.vertical_index, item.horizontal_index);
                        if (item.occupiedBypiece.white)
                        {
                            foreach (var PossibleMove in item.occupiedBypiece.possibleMoves)
                            {
                                PossibleAttacksList_White.Add(PossibleMove);
                            }
                        }
                        else
                        {
                            foreach (var PossibleMove in item.occupiedBypiece.possibleMoves)
                            {
                                PossibleAttacksList_Black.Add(PossibleMove);
                            }
                        }
                }
            }
        }
    }
}
