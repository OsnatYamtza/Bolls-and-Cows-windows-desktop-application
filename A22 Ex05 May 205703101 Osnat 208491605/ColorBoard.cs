using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A22_Ex05_May_205703101_Osnat_208491605
{
    public class ColorBoard : Form
    {
        public ePickColor i_PickColors;
        private Button m_Button1;
        private Button m_Button2;
        private Button m_Button3;
        private Button m_Button4;
        private Button m_Button5;
        private Button m_Button6;
        private Button m_Button7;
        private Button m_Button8;

        public ColorBoard()
        {
            initializedComponent();
        }

        // $G$ DSN-004 (-10) Unnecessary code duplication, the difference between buttons is to small. you should have made a method.
        // 100 ines of code on one method?! should turn on a red light!
        private void initializedComponent()
        {
            this.Name = "ColorBoard";
            this.Text = "Pick A Color";
            this.Load += new System.EventHandler(this.ColorBoard_Load);
            this.ResumeLayout(false);
            this.m_Button1 = new System.Windows.Forms.Button();
            this.m_Button2 = new System.Windows.Forms.Button();
            this.m_Button3 = new System.Windows.Forms.Button();
            this.m_Button4 = new System.Windows.Forms.Button();
            this.m_Button5 = new System.Windows.Forms.Button();
            this.m_Button6 = new System.Windows.Forms.Button();
            this.m_Button7 = new System.Windows.Forms.Button();
            this.m_Button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.m_Button1.Location = new System.Drawing.Point(13, 12);
            this.m_Button1.Name = "m_Button1";
            this.m_Button1.Size = new System.Drawing.Size(45, 35);
            this.m_Button1.TabIndex = 0;
            this.m_Button1.BackColor = Color.Purple;
            this.m_Button1.UseVisualStyleBackColor = true;
            this.m_Button1.Click += new System.EventHandler(this.button1_Click);

            this.m_Button2.Location = new System.Drawing.Point(64, 12);
            this.m_Button2.Name = "m_Button2";
            this.m_Button2.Size = new System.Drawing.Size(46, 35);
            this.m_Button2.TabIndex = 1;
            this.m_Button1.UseVisualStyleBackColor = true;
            this.m_Button2.BackColor = Color.Red;
            this.m_Button2.UseVisualStyleBackColor = true;
            this.m_Button2.Click += new System.EventHandler(this.button2_Click);

            this.m_Button3.Location = new System.Drawing.Point(116, 12);
            this.m_Button3.Name = "m_Button3";
            this.m_Button3.Size = new System.Drawing.Size(39, 35);
            this.m_Button3.TabIndex = 2;
            this.m_Button3.BackColor = Color.Green;
            this.m_Button3.UseVisualStyleBackColor = true;
            this.m_Button3.Click += new System.EventHandler(this.button3_Click);

            this.m_Button4.Location = new System.Drawing.Point(160, 12);
            this.m_Button4.Name = "m_Button4";
            this.m_Button4.Size = new System.Drawing.Size(39, 35);
            this.m_Button4.TabIndex = 3;
            this.m_Button4.BackColor = Color.LightBlue;
            this.m_Button4.UseVisualStyleBackColor = true;
            this.m_Button4.Click += new System.EventHandler(this.button4_Click);

            this.m_Button5.Location = new System.Drawing.Point(12, 62);
            this.m_Button5.Name = "m_Button5";
            this.m_Button5.Size = new System.Drawing.Size(46, 35);
            this.m_Button5.TabIndex = 4;
            this.m_Button5.BackColor = Color.Blue;
            this.m_Button5.UseVisualStyleBackColor = true;
            this.m_Button5.Click += new System.EventHandler(this.button5_Click);

            this.m_Button6.Location = new System.Drawing.Point(64, 62);
            this.m_Button6.Name = "m_Button6";
            this.m_Button6.Size = new System.Drawing.Size(46, 35);
            this.m_Button6.TabIndex = 5;
            this.m_Button6.BackColor = Color.Yellow;
            this.m_Button6.UseVisualStyleBackColor = true;
            this.m_Button6.Click += new System.EventHandler(this.button6_Click);

            this.m_Button7.Location = new System.Drawing.Point(116, 62);
            this.m_Button7.Name = "m_Button7";
            this.m_Button7.Size = new System.Drawing.Size(39, 35);
            this.m_Button7.TabIndex = 6;
            this.m_Button7.BackColor = Color.Brown;
            this.m_Button7.UseVisualStyleBackColor = true;
            this.m_Button7.Click += new System.EventHandler(this.button7_Click);

            this.m_Button8.Location = new System.Drawing.Point(160, 62);
            this.m_Button8.Name = "m_Button8";
            this.m_Button8.Size = new System.Drawing.Size(39, 35);
            this.m_Button8.TabIndex = 7;
            this.m_Button8.BackColor = Color.White;
            this.m_Button8.UseVisualStyleBackColor = true;
            this.m_Button8.Click += new System.EventHandler(this.button8_Click);

            this.ClientSize = new System.Drawing.Size(211, 113);
            this.Controls.Add(this.m_Button8);
            this.Controls.Add(this.m_Button7);
            this.Controls.Add(this.m_Button6);
            this.Controls.Add(this.m_Button5);
            this.Controls.Add(this.m_Button4);
            this.Controls.Add(this.m_Button3);
            this.Controls.Add(this.m_Button2);
            this.Controls.Add(this.m_Button1);
            this.Name = "ColorBoard";
            this.ResumeLayout(false);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.Purple;
            this.Hide(); // hides the settings window from the user
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.Red;
            this.Hide(); // hides the settings window from the user
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.Green;
            this.Hide(); // hides the settings window from the user
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.LightBlue;
            this.Hide(); // hides the settings window from the user
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.Blue;
            this.Hide(); // hides the settings window from the user
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.Yellow;
            this.Hide(); // hides the settings window from the user
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.Brown;
            this.Hide(); // hides the settings window from the user
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.i_PickColors = ePickColor.White;
            this.Hide(); // hides the settings window from the user
        }

        private void ColorBoard_Load(object sender, EventArgs e)
        {
        }
    }
}
