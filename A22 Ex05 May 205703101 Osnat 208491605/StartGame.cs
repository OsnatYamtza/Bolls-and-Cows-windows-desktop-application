using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A22_Ex05_May_205703101_Osnat_208491605
{
    public class StartGame : Form
    {
        private Button m_ButtonStart;
        private Button m_ButtonNumberOfChances;
        private int m_NumberOfChances = 4;

        public StartGame()
        {
            initializeComponent();
        }

        // $G$ CSS-027 (-3) Spaces are not kept as required after defying variables.
        private void createBoard(int o_NumberOfChances)
        {
            BoardGameApplication boardGameApplication;
            boardGameApplication = new BoardGameApplication(o_NumberOfChances);
            this.Hide(); // hides the settings window from the user
            boardGameApplication.ShowDialog(); // shows the game application itself
        }

        private void initializeComponent()
        {
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.m_ButtonNumberOfChances = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Button Start
            this.m_ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_ButtonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ButtonStart.Location = new System.Drawing.Point(142, 189);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(112, 39);
            this.m_ButtonStart.TabIndex = 0;
            this.m_ButtonStart.Text = "Start";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new System.EventHandler(this.buttonStart_Click);

            // Button Number Of Chances
            this.m_ButtonNumberOfChances.Location = new System.Drawing.Point(49, 23);
            this.m_ButtonNumberOfChances.Name = "m_ButtonNumberOfChances";
            this.m_ButtonNumberOfChances.Size = new System.Drawing.Size(179, 40);
            this.m_ButtonNumberOfChances.TabIndex = 1;
            this.m_ButtonNumberOfChances.Text = "Number of chances: 4";
            this.m_ButtonNumberOfChances.UseVisualStyleBackColor = true;
            this.m_ButtonNumberOfChances.Click += new System.EventHandler(this.buttonNumberOfChances_Click);

            // Button Start Game
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.m_ButtonNumberOfChances);
            this.Controls.Add(this.m_ButtonStart);
            this.Name = "StartGame";
            this.Text = "Bool Pgia";
            this.Load += new System.EventHandler(this.StartGame_Load);
            this.ResumeLayout(false);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            createBoard(this.m_NumberOfChances);
        }

        private void buttonNumberOfChances_Click(object sender, EventArgs e)
        {
            if (this.m_NumberOfChances == 10)
            {
                this.m_ButtonNumberOfChances.Text = "Number of chances: 4";
                this.m_NumberOfChances = 4;
            }
            else
            {
                this.m_ButtonNumberOfChances.Text = "Number of chances: " + ++this.m_NumberOfChances;
            }
        }

        private void StartGame_Load(object sender, EventArgs e)
        {
        }
    }
}
