using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A22_Ex05_May_205703101_Osnat_208491605
{
    public class BoardGameApplication : Form
    {
        private const int k_DefaultDistance = 20;
        private int m_RowsNumber;
        private int m_RowLocation;
        private int m_RowOfindex = 0;
        private int m_ColorButtonChose;
        private int c_ColumnsNumber = 4;
        private int[] m_CheckedIndex;
        private int[] m_ComputerRandomGuess;
        private Button[] m_ButtonsColumns;
        private Button[,] m_ButtonsBoard;
        private Button[,] m_CheckButtonsBoard;
        private Color m_ColorNumberChose;
        private ColorBoard m_ColorBoard;
        private Random m_RandomGuess;

        public BoardGameApplication(int i_NumberOfChances)
        {
            m_RowsNumber = i_NumberOfChances;
            m_ButtonsBoard = new Button[m_RowsNumber, c_ColumnsNumber + 5];
            m_ButtonsColumns = new Button[c_ColumnsNumber];
            m_CheckButtonsBoard = new Button[2 * m_RowsNumber, 2];
            m_RandomGuess = new Random();
            m_ComputerRandomGuess = new int[c_ColumnsNumber];
            m_CheckedIndex = new int[c_ColumnsNumber];
            computerRandomGuess();
            InitializedComponent();
        }

        public void CreateColorBoard()
        {
            this.m_ColorBoard = new ColorBoard();
            m_ColorBoard.ShowDialog(); // shows the game application itself
        }

        // $G$ DSN-003 (-5) The code should be divided to methods. 
        // 150 ines of code on one method?! should turn on a red light!
        private void InitializedComponent()
        {
            this.Name = "BoardGameApplication";
            this.Text = "Bool Pgia";
            this.Load += new System.EventHandler(this.BoardGameApplication_Load);
            this.ResumeLayout(false);

            // Computer guess, first black
            m_ButtonsColumns[0] = new Button();
            m_ButtonsColumns[0].Left = k_DefaultDistance;
            m_ButtonsColumns[0].Top = k_DefaultDistance;
            m_ButtonsColumns[0].Width = k_DefaultDistance * 2;
            m_ButtonsColumns[0].Height = k_DefaultDistance * 2;
            m_ButtonsColumns[0].BackColor = Color.Black;
            this.Controls.Add(m_ButtonsColumns[0]);

            for (int i = 1; i < c_ColumnsNumber; i++)
            {
                m_ButtonsColumns[i] = new Button();
                m_ButtonsColumns[i].Width = k_DefaultDistance * 2;
                m_ButtonsColumns[i].Height = k_DefaultDistance * 2;
                m_ButtonsColumns[i].Left = m_ButtonsColumns[i - 1].Right + (k_DefaultDistance / 5);
                m_ButtonsColumns[i].BackColor = Color.Black;
                m_ButtonsColumns[i].Top = m_ButtonsColumns[i - 1].Top;
                this.Controls.Add(m_ButtonsColumns[i]);
            }

            m_ButtonsBoard[0, c_ColumnsNumber] = new Button();
            m_ButtonsBoard[0, c_ColumnsNumber].Width = k_DefaultDistance * 2;
            m_ButtonsBoard[0, c_ColumnsNumber].Height = k_DefaultDistance;
            m_ButtonsBoard[0, c_ColumnsNumber].Left = m_ButtonsColumns[c_ColumnsNumber - 1].Left + (k_DefaultDistance * 3);
            m_ButtonsBoard[0, c_ColumnsNumber].Top = m_ButtonsColumns[c_ColumnsNumber - 1].Bottom + k_DefaultDistance + 10;
            m_ButtonsBoard[0, c_ColumnsNumber].Text = "-->>";
            m_ButtonsBoard[0, c_ColumnsNumber].Enabled = false;
            m_ButtonsBoard[m_RowOfindex, c_ColumnsNumber].Click += new EventHandler(ButtonsArrow_Click);
            this.Controls.Add(m_ButtonsBoard[0, c_ColumnsNumber]);

            // board buttons setup
            for (int j = 0; j < c_ColumnsNumber; j++)
            {
                m_ButtonsBoard[0, j] = new Button();
                m_ButtonsBoard[0, j].Width = k_DefaultDistance * 2;
                m_ButtonsBoard[0, j].Height = k_DefaultDistance * 2;
                m_ButtonsBoard[0, j].Left = m_ButtonsColumns[j].Left;
                m_ButtonsBoard[0, j].Top = m_ButtonsColumns[j].Bottom + k_DefaultDistance;
                this.Controls.Add(m_ButtonsBoard[0, j]);
                m_RowLocation = m_ButtonsColumns[j].Bottom + k_DefaultDistance;
                m_ButtonsBoard[0, j].Click += new EventHandler(ButtonsColumnsRest_Click);
            }

            this.Width = m_ButtonsColumns[c_ColumnsNumber - 1].Right + k_DefaultDistance + (k_DefaultDistance * 6);
            this.Height = m_ButtonsBoard[0, 0].Bottom + (k_DefaultDistance * 3);

            // first row user guess result
            m_ButtonsBoard[0, c_ColumnsNumber + 1] = new Button();
            m_ButtonsBoard[0, c_ColumnsNumber + 1].Width = k_DefaultDistance - 10;
            m_ButtonsBoard[0, c_ColumnsNumber + 1].Height = k_DefaultDistance - 8;
            m_ButtonsBoard[0, c_ColumnsNumber + 1].Left = m_ButtonsColumns[c_ColumnsNumber - 1].Left + (k_DefaultDistance * 6);
            m_ButtonsBoard[0, c_ColumnsNumber + 1].Top = m_ButtonsColumns[c_ColumnsNumber - 1].Bottom + k_DefaultDistance;
            m_ButtonsBoard[0, c_ColumnsNumber + 1].Enabled = false;
            this.Controls.Add(m_ButtonsBoard[0, c_ColumnsNumber + 1]);

            m_ButtonsBoard[0, c_ColumnsNumber + 2] = new Button();
            m_ButtonsBoard[0, c_ColumnsNumber + 2].Width = k_DefaultDistance - 10;
            m_ButtonsBoard[0, c_ColumnsNumber + 2].Height = k_DefaultDistance - 8;
            m_ButtonsBoard[0, c_ColumnsNumber + 2].Left = m_ButtonsColumns[c_ColumnsNumber - 1].Left + (k_DefaultDistance * 7);
            m_ButtonsBoard[0, c_ColumnsNumber + 2].Top = m_ButtonsColumns[c_ColumnsNumber - 1].Bottom + k_DefaultDistance;
            m_ButtonsBoard[0, c_ColumnsNumber + 2].Enabled = false;
            this.Controls.Add(m_ButtonsBoard[0, c_ColumnsNumber + 2]);

            m_ButtonsBoard[0, c_ColumnsNumber + 3] = new Button();
            m_ButtonsBoard[0, c_ColumnsNumber + 3].Width = k_DefaultDistance - 10;
            m_ButtonsBoard[0, c_ColumnsNumber + 3].Height = k_DefaultDistance - 8;
            m_ButtonsBoard[0, c_ColumnsNumber + 3].Left = m_ButtonsColumns[c_ColumnsNumber - 1].Left + (k_DefaultDistance * 6);
            m_ButtonsBoard[0, c_ColumnsNumber + 3].Top = m_ButtonsColumns[c_ColumnsNumber - 1].Bottom + (k_DefaultDistance * 2);
            m_ButtonsBoard[0, c_ColumnsNumber + 3].Enabled = false;
            this.Controls.Add(m_ButtonsBoard[0, c_ColumnsNumber + 3]);

            m_ButtonsBoard[0, c_ColumnsNumber + 4] = new Button();
            m_ButtonsBoard[0, c_ColumnsNumber + 4].Width = k_DefaultDistance - 10;
            m_ButtonsBoard[0, c_ColumnsNumber + 4].Height = k_DefaultDistance - 8;
            m_ButtonsBoard[0, c_ColumnsNumber + 4].Left = m_ButtonsColumns[c_ColumnsNumber - 1].Left + (k_DefaultDistance * 7);
            m_ButtonsBoard[0, c_ColumnsNumber + 4].Top = m_ButtonsColumns[c_ColumnsNumber - 1].Bottom + (k_DefaultDistance * 2);
            m_ButtonsBoard[0, c_ColumnsNumber + 4].Enabled = false;
            this.Controls.Add(m_ButtonsBoard[0, c_ColumnsNumber + 4]);

            for (int i = 1; i < m_RowsNumber; i++)
            {
                for (int j = 0; j < c_ColumnsNumber; j++)
                {
                    m_ButtonsBoard[i, j] = new Button();
                    m_ButtonsBoard[i, j].Width = k_DefaultDistance * 2;
                    m_ButtonsBoard[i, j].Height = k_DefaultDistance * 2;
                    m_ButtonsBoard[i, j].Left = m_ButtonsBoard[i - 1, j].Left;
                    m_ButtonsBoard[i, j].Top = m_ButtonsBoard[i - 1, j].Bottom + 5;
                    this.Controls.Add(m_ButtonsBoard[i, j]);
                    m_ButtonsBoard[i, j].Click += new EventHandler(ButtonsColumnsRest_Click);
                }

                m_ButtonsBoard[i, c_ColumnsNumber] = new Button();
                m_ButtonsBoard[i, c_ColumnsNumber].Width = k_DefaultDistance * 2;
                m_ButtonsBoard[i, c_ColumnsNumber].Height = k_DefaultDistance;
                m_ButtonsBoard[i, c_ColumnsNumber].Left = m_ButtonsBoard[i, c_ColumnsNumber - 1].Left + (k_DefaultDistance * 3);
                m_ButtonsBoard[i, c_ColumnsNumber].Top = m_ButtonsBoard[i - 1, c_ColumnsNumber - 1].Bottom + k_DefaultDistance;
                m_ButtonsBoard[i, c_ColumnsNumber].Text = "-->>";
                m_ButtonsBoard[i, c_ColumnsNumber].Enabled = false;
                m_ButtonsBoard[i, c_ColumnsNumber].Click += new EventHandler(ButtonsArrow_Click);
                this.Controls.Add(m_ButtonsBoard[i, c_ColumnsNumber]);
                this.Height += m_ButtonsBoard[i, 0].Height + 5;

                m_ButtonsBoard[i, c_ColumnsNumber + 1] = new Button();
                m_ButtonsBoard[i, c_ColumnsNumber + 1].Width = k_DefaultDistance - 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 1].Height = k_DefaultDistance - 8;
                m_ButtonsBoard[i, c_ColumnsNumber + 1].Left = m_ButtonsBoard[i, c_ColumnsNumber - 1].Left + (k_DefaultDistance * 6);
                m_ButtonsBoard[i, c_ColumnsNumber + 1].Top = m_ButtonsBoard[i - 1, c_ColumnsNumber - 1].Bottom + 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 1].Enabled = false;
                this.Controls.Add(m_ButtonsBoard[i, c_ColumnsNumber + 1]);

                m_ButtonsBoard[i, c_ColumnsNumber + 3] = new Button();
                m_ButtonsBoard[i, c_ColumnsNumber + 3].Width = k_DefaultDistance - 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 3].Height = k_DefaultDistance - 8;
                m_ButtonsBoard[i, c_ColumnsNumber + 3].Left = m_ButtonsBoard[i, c_ColumnsNumber - 1].Left + (k_DefaultDistance * 6);
                m_ButtonsBoard[i, c_ColumnsNumber + 3].Top = m_ButtonsBoard[i - 1, c_ColumnsNumber - 1].Bottom + k_DefaultDistance + 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 3].Enabled = false;
                this.Controls.Add(m_ButtonsBoard[i, c_ColumnsNumber + 3]);

                m_ButtonsBoard[i, c_ColumnsNumber + 2] = new Button();
                m_ButtonsBoard[i, c_ColumnsNumber + 2].Width = k_DefaultDistance - 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 2].Height = k_DefaultDistance - 8;
                m_ButtonsBoard[i, c_ColumnsNumber + 2].Left = m_ButtonsBoard[i, c_ColumnsNumber - 1].Left + (k_DefaultDistance * 7);
                m_ButtonsBoard[i, c_ColumnsNumber + 2].Top = m_ButtonsBoard[i - 1, c_ColumnsNumber - 1].Bottom + 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 2].Enabled = false;
                this.Controls.Add(m_ButtonsBoard[i, c_ColumnsNumber + 2]);

                m_ButtonsBoard[i, c_ColumnsNumber + 4] = new Button();
                m_ButtonsBoard[i, c_ColumnsNumber + 4].Width = k_DefaultDistance - 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 4].Height = k_DefaultDistance - 8;
                m_ButtonsBoard[i, c_ColumnsNumber + 4].Left = m_ButtonsBoard[i, c_ColumnsNumber - 1].Left + (k_DefaultDistance * 7);
                m_ButtonsBoard[i, c_ColumnsNumber + 4].Top = m_ButtonsBoard[i - 1, c_ColumnsNumber - 1].Bottom + k_DefaultDistance + 10;
                m_ButtonsBoard[i, c_ColumnsNumber + 4].Enabled = false;
                this.Controls.Add(m_ButtonsBoard[i, c_ColumnsNumber + 4]);
            }

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void computerRandomGuess()
        {
            int i = 0, j, randomChar;

            while (i < 4)
            {
                randomChar = (int)(ePickColor)m_RandomGuess.Next((int)ePickColor.Purple, (int)ePickColor.White);
                if (i == 0)
                {
                    m_ComputerRandomGuess[i] = randomChar;
                    i++;
                }
                else
                {
                    for (j = i; j > 0; j--)
                    {
                        if (randomChar == m_ComputerRandomGuess[j - 1])
                        {
                            break;
                        }
                    }

                    if (j == 0)
                    {
                        m_ComputerRandomGuess[i] = randomChar;
                        i++;
                    }
                }
            }
        }

        private void ButtonsColumnsRest_Click(object sender, EventArgs e)
        {
            Button buttonClicked = sender as Button;

            if (buttonClicked.Top == m_RowLocation)
            {
                CreateColorBoard();
                colorChose(buttonClicked);
                checkColorsRight(buttonClicked);
            }
        }

        private void ButtonsArrow_Click(object sender, EventArgs e)
        {
            if (m_RowOfindex < m_RowsNumber)
            {
                m_ButtonsBoard[m_RowOfindex, c_ColumnsNumber].Enabled = false;
            }

            checkIfUserRight();

            if (m_RowOfindex == m_RowsNumber)
            {
                showComputerGuess();
            }
        }

        private void BoardGameApplication_Load(object sender, EventArgs e)
        {
        }

        private void colorChose(Button i_ButtonClicked)
        {
            if ((int)m_ColorBoard.i_PickColors == 0)
            {
                i_ButtonClicked.BackColor = Color.Purple;
            }

            if ((int)m_ColorBoard.i_PickColors == 1)
            {
                i_ButtonClicked.BackColor = Color.Red;
            }

            if ((int)m_ColorBoard.i_PickColors == 2)
            {
                i_ButtonClicked.BackColor = Color.Green;
            }

            if ((int)m_ColorBoard.i_PickColors == 3)
            {
                i_ButtonClicked.BackColor = Color.LightBlue;
            }

            if ((int)m_ColorBoard.i_PickColors == 4)
            {
                i_ButtonClicked.BackColor = Color.Blue;
            }

            if ((int)m_ColorBoard.i_PickColors == 5)
            {
                i_ButtonClicked.BackColor = Color.Yellow;
            }

            if ((int)m_ColorBoard.i_PickColors == 6)
            {
                i_ButtonClicked.BackColor = Color.Brown;
            }

            if ((int)m_ColorBoard.i_PickColors == 7)
            {
                i_ButtonClicked.BackColor = Color.White;
            }
        }

        private void checkColorsRight(Button i_ButtonClicked)
        {
            bool is_checkIfButtonColored = true;
            bool is_checkIfColorButtonDifferent = true;

            for (int j = 0; j < c_ColumnsNumber; j++)
            {
                if (m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.Purple && m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.Green && m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.LightBlue
                    && m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.Blue && m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.Yellow && m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.Brown
                    && m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.White && m_ButtonsBoard[m_RowOfindex, j].BackColor != Color.Red)
                {
                    is_checkIfButtonColored = false;
                }
            }

            for (int j = 0; j < c_ColumnsNumber - 1; j++)
            {
                for (int i = 1; i < c_ColumnsNumber; i++)
                {
                    if (j != i)
                    {
                        if (m_ButtonsBoard[m_RowOfindex, j].BackColor == m_ButtonsBoard[m_RowOfindex, i].BackColor)
                        {
                            is_checkIfColorButtonDifferent = false;
                        }
                    }
                }
            }

            if (is_checkIfButtonColored == true && is_checkIfColorButtonDifferent == true)
            {
                m_ButtonsBoard[m_RowOfindex, c_ColumnsNumber].Enabled = true;
                m_RowLocation = i_ButtonClicked.Bottom + 5;
            }
        }

        private void checkIfUserRight()
        {
            int userGuess = 0;
            int bullIndex = 1;

            for (int i = 0; i < c_ColumnsNumber; i++)
            {
                getButtonColor(m_ButtonsBoard[m_RowOfindex, i].BackColor);
                if (m_ComputerRandomGuess[i] == m_ColorButtonChose)
                {
                    m_ButtonsBoard[m_RowOfindex, c_ColumnsNumber + bullIndex].BackColor = Color.Black;
                    m_CheckedIndex[i] = 1;
                    bullIndex++;
                }
            }

            // case user was right
            for (int i = 0; i < c_ColumnsNumber; i++)
            {
                if (m_CheckedIndex[i] == 1)
                {
                    userGuess++;
                }
            }

            if(userGuess == 4)
            {
                showComputerGuess();
            }

            for (int i = 0; i < c_ColumnsNumber; i++)
            {
                if (m_CheckedIndex[i] != 1)
                {
                    getButtonColor(m_ButtonsBoard[m_RowOfindex, i].BackColor);
                    for (int j = 0; j < c_ColumnsNumber; j++)
                    {
                        if (m_ComputerRandomGuess[j] == m_ColorButtonChose)
                        {
                            m_ButtonsBoard[m_RowOfindex, c_ColumnsNumber + bullIndex].BackColor = Color.Yellow;
                            bullIndex++;
                        }
                    }
                }
            }

            this.m_RowOfindex++;
        }

        private void getButtonColor(Color i_ColorSelected)
        {
            if (i_ColorSelected == Color.Red)
            {
                m_ColorButtonChose = 1;
            }

            if (i_ColorSelected == Color.Green)
            {
                m_ColorButtonChose = 2;
            }

            if (i_ColorSelected == Color.White)
            {
                m_ColorButtonChose = 7;
            }

            if (i_ColorSelected == Color.Purple)
            {
                m_ColorButtonChose = 0;
            }

            if (i_ColorSelected == Color.Brown)
            {
                m_ColorButtonChose = 6;
            }

            if (i_ColorSelected == Color.Yellow)
            {
                m_ColorButtonChose = 5;
            }

            if (i_ColorSelected == Color.Blue)
            {
                m_ColorButtonChose = 4;
            }

            if (i_ColorSelected == Color.LightBlue)
            {
                m_ColorButtonChose = 3;
            }
        }

        private void getNumberColor(int i_ColorSelectedNumber)
        {
            if (i_ColorSelectedNumber == 1)
            {
                m_ColorNumberChose = Color.Red;
            }

            if (i_ColorSelectedNumber == 2)
            {
                m_ColorNumberChose = Color.Green;
            }

            if (i_ColorSelectedNumber == 7)
            {
                m_ColorNumberChose = Color.White;
            }

            if (i_ColorSelectedNumber == 0)
            {
                m_ColorNumberChose = Color.Purple;
            }

            if (i_ColorSelectedNumber == 6)
            {
                m_ColorNumberChose = Color.Brown;
            }

            if (i_ColorSelectedNumber == 5)
            {
                m_ColorNumberChose = Color.Yellow;
            }

            if (i_ColorSelectedNumber == 4)
            {
                m_ColorNumberChose = Color.Blue;
            }

            if (i_ColorSelectedNumber == 3)
            {
                m_ColorNumberChose = Color.LightBlue;
            }
        }

        private void showComputerGuess()
        {
            for (int i = 0; i < c_ColumnsNumber; i++)
            {
                getNumberColor(m_ComputerRandomGuess[i]);
                m_ButtonsColumns[i].BackColor = m_ColorNumberChose;
                this.Controls.Add(m_ButtonsColumns[i]);
            }
        }
    }
}
