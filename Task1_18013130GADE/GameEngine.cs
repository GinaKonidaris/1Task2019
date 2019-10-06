using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_18013130GADE
{
    class GameEngine : Form
    {

        Map map = new Map(20, 20, 20);
        const int START_X = 20;
        const int START_Y = 20;
        const int SPACING = 10;
        const int SIZE = 20;
        Random r = new Random();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void InitializeMyGroupBox()
        {
            // Create and initialize a GroupBox and a Button control.
            GroupBox groupBox1 = new GroupBox();
            foreach (Unit u in map.Units)
            {
                if (GetType() == typeof(MeleeUnit))
                {//creating buttons
                    int start_x; int start_y;
                    start_x = groupBox1.Location.X;
                    start_y = groupBox1.Location.Y;
                    MeleeUnit n = (MeleeUnit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(START_X + (n.Xpos * SIZE), START_Y + (n.Ypos * SIZE));
                    b.Text = n.Symbol;
                    if (n.Team == 1)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                    if (n.Isdead())
                    {
                        b.ForeColor = Color.Black;
                    }

                    b.Click += new EventHandler(btnButton_Click);
                    groupBox1.Controls.Add(b);

                    this.Controls.Add(b);
                }
            }

        }
        void btnButton_Click(object sender, EventArgs e)
        {

        }

     }
}

    

