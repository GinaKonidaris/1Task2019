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
    public partial class Form1 : Form
    {
        Map map = new Map(20, 20, 20);
        const int START_X = 20;
        const int START_Y = 20;
        const int SPACING = 10;
        const int SIZE = 20;
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayMap();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtInfo.Text = DateTime.Now.ToLongTimeString();       
        }
        private void DisplayMap()
        {  
            groupBox1.Controls.Clear();
            
        }
        public void UpdateMap()
        {
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit n = (MeleeUnit)u;
                    if (n.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((MeleeUnit)u).Move(Direction.North); break;
                            case 1: ((MeleeUnit)u).Move(Direction.East); break;
                            case 2: ((MeleeUnit)u).Move(Direction.South); break;
                            case 3: ((MeleeUnit)u).Move(Direction.West); break;
                        }
                    }
                    else // In comabt or moving towards
                    {
                        bool inCombat = false;

                        foreach (Unit e in map.Units)
                        {
                            if (u.Inranged(e)) // Incombat
                            {
                                u.Combat(e);
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.Closest(map.Units);

                            u.Move(n.DirectionTo(c));

                        }
                    }
                }
            }
        }
            private void Timer2_Tick(object sender, EventArgs e)
        {
            UpdateMap();
            DisplayMap();
        }
        private void Button_click(object sender, EventArgs e)
        {
            int x = ((Button)sender).Location.X / SIZE - groupBox1.Location.X / SIZE;
            int y = ((Button)sender).Location.Y / SIZE - groupBox1.Location.Y / SIZE;
            foreach (MeleeUnit u in map.Units)
            {

                if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit n = (MeleeUnit)u;
                    if (n.Xpos == x && n.Ypos == y)
                    {
                        txtInfo.Text = "Button CLicked at" + n.Tostring();
                    }

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
